using UnityEngine;
using System.Collections;

public class EighthNoteAnim : Anim {
	
	private UVAnimation standAnim;
	private UVAnimation moveAnim;
	
	
	protected override void createSprite() {
		sprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0f, 10f/numRows), cellSize, Vector3.zero, false);
	}
	
	protected override void createAnimations() {
		// Set up standing animation
		standAnim = new UVAnimation();
		standAnim.name = "EighthNote Standing Animation";
		standAnim.loopCycles = -1;
		standAnim.framerate = 24;
		
		standAnim.BuildUVAnim(new Vector2(0f, 10f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(standAnim);
	
		// Set up moving animation
		moveAnim = new UVAnimation();
		moveAnim.name = "EighthNote Moving Animation";
		moveAnim.loopCycles = -1;
		moveAnim.framerate = 24;
		
		moveAnim.BuildUVAnim(new Vector2(0f, 9f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(moveAnim);
		
		// Play starting animation
		playStandingAnim();
	}
	
	public void playStandingAnim() {
		sprite.PlayAnim(standAnim);	
	}
	
	public void playMovingAnim() {
		sprite.PlayAnim(moveAnim);
	}
}
