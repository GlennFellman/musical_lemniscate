//-----------------------------------------------------------------
//  LinkedSpriteManager v0.64 (21-10-2012)
//  Copyright 2012 Brady Wright and Above and Beyond Software
//  All rights reserved
//-----------------------------------------------------------------
// A class to allow the drawing of multiple "quads" as part of a
// single aggregated mesh so as to achieve multiple, independently
// moving objects using a single draw call.
//-----------------------------------------------------------------
 
 
using UnityEngine;
using System.Collections;
 
// A variation on the SpriteManager that automatically links all
// translations and rotations of the client GameObjects to the
// associated sprite - meaning the client need not worry about
// micromanaging all transformations:
public class LinkedSpriteManager : SpriteManager 
{
	Transform t;
	Vector3 pos;
	Sprite s;
 
 
	// Use this for initialization
	void Start () 
	{
 
	}
 
	// Transforms all sprites by their associated GameObject's
	// transforms:
	void TransformSprites()
	{
		for(int i=0; i<activeBlocks.Count; ++i)
		{
			((Sprite)activeBlocks[i]).Transform();
		}
 
		// Handle any billboarded sprites:
		if(activeBillboards.Count > 0)
		{
			t = Camera.main.transform;
 
			for(int i=0; i<activeBillboards.Count; ++i)
			{
				s = (Sprite)activeBillboards[i];
				pos = s.clientTransform.position;
 
				vertices[s.mv1] = pos + t.TransformDirection(s.v1);
				vertices[s.mv2] = pos + t.TransformDirection(s.v2);
				vertices[s.mv3] = pos + t.TransformDirection(s.v3);
				vertices[s.mv4] = pos + t.TransformDirection(s.v4);
			}
		}
	}
 
	// LateUpdate is called once per frame
	new void LateUpdate() 
	{
		// Transform all sprites according to their
		// client GameObject's transforms:
		TransformSprites();
 
		// Copy over the changes:
		mesh.vertices = vertices;
 
		// See if we have any active animations:
		if (playingAnimations.Count > 0)
		{
			animTimeElapsed = Time.deltaTime;
 
			for (i = 0; i < playingAnimations.Count; ++i)
			{
				tempSprite = (Sprite)playingAnimations[i];
 
				// Step the animation, and if it has finished
				// playing, remove it from the playing list:
				if (!tempSprite.StepAnim(animTimeElapsed))
					playingAnimations.Remove(tempSprite);
			}
 
			uvsChanged = true;
		}
 
		if (vertCountChanged)
		{
			mesh.uv = UVs;
			mesh.colors = colors;
			mesh.normals = normals;
			mesh.triangles = triIndices;
 
			vertCountChanged = false;
			uvsChanged = false;
			colorsChanged = false;
		}
		else
		{
			if (uvsChanged)
			{
				mesh.uv = UVs;
				uvsChanged = false;
			}
 
			if (colorsChanged)
			{
				colorsChanged = false;
 
				mesh.colors = colors;
			}
 
			// Explicitly recalculate bounds since
			// we didn't assign new triangles (which
			// implicitly recalculates bounds)
			if (updateBounds || autoUpdateBounds)
			{
				mesh.RecalculateBounds();
				updateBounds = false;
			}
		}
	}
	
	public void changeFrameRate() {
		int fr;
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		if (player.isFastMusic)
			fr = 48;
		else
			fr = 24;
		
		foreach (Sprite sprite in sprites) {
			foreach (UVAnimation anim in sprite.animations) {
				anim.framerate = fr;	
				sprite.PlayAnim(anim);
			}
		}
	}
	
	public void changeDir(Transform transform, bool isMovingRight) {		
		Sprite rightSprite = null;
		
		// Find sprite
		foreach (Sprite sprite in sprites) {
			if (transform == sprite.clientTransform) {
				rightSprite = sprite;
				break;
			}
		}
		
		// Incorrect call?
		if (rightSprite.animations.Count < 2)
			return;
		
		// Change animation
		if (isMovingRight)
			rightSprite.PlayAnim((UVAnimation)rightSprite.animations[1]);
		else
			rightSprite.PlayAnim((UVAnimation)rightSprite.animations[0]);
	}
	
	public void changeMovement(Transform transform, bool isMoving) {		
		Sprite rightSprite = null;
		
		// Find sprite
		foreach (Sprite sprite in sprites) {
			if (transform == sprite.clientTransform) {
				rightSprite = sprite;
				break;
			}
		}
		
		// Incorrect call?
		if (rightSprite.animations.Count < 2)
			return;
		
		// Change animation
		if (isMoving)
			rightSprite.PlayAnim((UVAnimation)rightSprite.animations[0]);
		else
			rightSprite.PlayAnim((UVAnimation)rightSprite.animations[0]);
	}
}