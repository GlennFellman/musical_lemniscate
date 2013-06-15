using UnityEngine;
using System.Collections;

public class QuarterRestAnim : Anim {
	
	private UVAnimation leftAnim;
	private UVAnimation rightAnim;
	
	protected override void createSprite() {
		sprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0f, 7f/numRows), cellSize, Vector3.zero, false);
	}
	
	protected override void createAnimations() {
		// Set up left animation
		leftAnim = new UVAnimation();
		leftAnim.name = "QuarterRest Left Animation";
		leftAnim.loopCycles = -1;
		leftAnim.framerate = 24;
		
		leftAnim.BuildUVAnim(new Vector2(0f, 7f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(leftAnim);

		
		// Set up right animation
		rightAnim = new UVAnimation();
		rightAnim.name = "QuarterRest Right Animation";
		rightAnim.loopCycles = -1;
		rightAnim.framerate = 24;
		
		rightAnim.BuildUVAnim(new Vector2(0f, 6f/numRows), cellSize, 18, 1, 18, 24);
		sprite.AddAnimation(rightAnim);
		
		// Starting direction
		QuarterRest qr = this.gameObject.GetComponent(typeof(QuarterRest)) as QuarterRest;
		if (qr.isMovingRight)
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
//	
//	
//	
//	
//	public LinkedSpriteManager spriteManager;
//	
//	// Use this for initialization
//	void Start () {
//		DrawSharpAnimation();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	
//	public void DrawSharpAnimation() {
//		// Put sprite on client objects
//		GameObject[] clients = GameObject.FindGameObjectsWithTag("QuarterRest");
//		foreach (GameObject client in clients) {
//			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 7f/15f), new Vector2(1f/18f, 1f/15f), Vector3.zero, false);
//		
//			// Set up left animation
//			UVAnimation lAnim = new UVAnimation();
//			lAnim.name = "QuarterRest Left Animation";
//			lAnim.loopCycles = -1;
//			lAnim.framerate = 24;
//			
//			lAnim.BuildUVAnim(new Vector2(0f, 7f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
//			
//			// Prepare sprite
//			clientSprite.AddAnimation(lAnim);
//			
//			// Set up right animation
//			UVAnimation rAnim = new UVAnimation();
//			rAnim.name = "QuarterRest Right Animation";
//			rAnim.loopCycles = -1;
//			rAnim.framerate = 24;
//			
//			rAnim.BuildUVAnim(new Vector2(0f, 6f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
//			
//			// Prepare sprite
//			clientSprite.AddAnimation(rAnim);
//			
//			
//			// Starting direction
//			QuarterRest qr = client.GetComponent(typeof(QuarterRest)) as QuarterRest;
//			if (qr.isMovingRight)
//				clientSprite.PlayAnim("QuarterRest Right Animation");
//			else
//				clientSprite.PlayAnim("QuarterRest Left Animation");
//		}
//	}
//}
