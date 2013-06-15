using UnityEngine;
using System.Collections;

public class EighthRestAnim : Anim {
	
	private UVAnimation leftAnim;
	private UVAnimation rightAnim;
	
	protected override void createSprite() {
		sprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0f, 12f/numRows), cellSize, Vector3.zero, false);
	}
	
	protected override void createAnimations() {
		// Set up left animation
		leftAnim = new UVAnimation();
		leftAnim.name = "EighthRest Left Animation";
		leftAnim.loopCycles = -1;
		leftAnim.framerate = 24;
		
		leftAnim.BuildUVAnim(new Vector2(0f, 12f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(leftAnim);

		
		// Set up right animation
		rightAnim = new UVAnimation();
		rightAnim.name = "EighthRest Right Animation";
		rightAnim.loopCycles = -1;
		rightAnim.framerate = 24;
		
		rightAnim.BuildUVAnim(new Vector2(0f, 11f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(rightAnim);
		
		// Starting direction
		EighthRest er = this.gameObject.GetComponent(typeof(EighthRest)) as EighthRest;
		if (er.isMovingRight)
			sprite.PlayAnim(rightAnim);
		else
			sprite.PlayAnim(leftAnim);	
	}
	
	public void playLeftAnim() {
		sprite.PlayAnim(leftAnim);	
	}
	
	public void playRightAnim() {
		sprite.PlayAnim(rightAnim);
	}
}