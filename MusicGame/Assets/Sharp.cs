using UnityEngine;
using System.Collections;

public class Sharp : Modifier {
//	public SpriteManager spriteManager;
//	
//	public override void Start() {
//		DrawSharpAnimation();	
//	}
//	
//	public void DrawSharpAnimation() {
//		// Put sprite on client object
//		GameObject client = GameObject.Find ("Sharp");
//		Sprite clientSprite = spriteManager.AddSprite(client, 10f, 10f, new Vector2(0f, 1798f/2048f), new Vector2(250f/2048f, 250f/2048f), Vector3.zero, false);
//		
//		// Set up animation
//		UVAnimation sharpAnim = new UVAnimation();
//		sharpAnim.name = "Sharp Animation";
//		sharpAnim.loopCycles = -1;
//		sharpAnim.framerate = 24;
//		
//		sharpAnim.BuildUVAnim(new Vector2(0f, 1798f/2048f), new Vector2(250f/2048f, 250f/2048f), 8, 3, 18, 24);
//		
//		// Prepare sprite
//		clientSprite.AddAnimation(sharpAnim);
//		clientSprite.PlayAnim("Sharp Animation");
//	}
	
	public override void changeModifierSignal() {
		ModifierSignal ms = GameObject.FindObjectOfType(typeof(ModifierSignal)) as ModifierSignal;
		ms.changeMaterial(GameConstants.Modifiers.Sharp);
	}
}
