using UnityEngine;
using System.Collections;

public class QuarterNoteAnim : Anim {
	
	private UVAnimation anim;
	
	protected override void createSprite() {
		sprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0f, 4f/numRows), cellSize, Vector3.zero, false);
	}
	
	protected override void createAnimations() {
		// Set up animation
		anim = new UVAnimation();
		anim.name = "QuarterNote Animation";
		anim.loopCycles = -1;
		anim.framerate = 24;
		
		anim.BuildUVAnim(new Vector2(0f, 4f/numRows), cellSize, 18, 2, 36, 24);
		sprite.AddAnimation(anim);

		sprite.PlayAnim(anim);	
	}
}
