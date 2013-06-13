using UnityEngine;
using System.Collections;

public class EighthNoteAnim : MonoBehaviour {
	
	public LinkedSpriteManager spriteManager;

	// Use this for initialization
	void Start () {
		//spriteManager = GameObject.FindObjectOfType(typeof(LinkedSpriteManager)) as LinkedSpriteManager;		
		DrawSharpAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DrawSharpAnimation() {
		// Put sprite on client objects
		GameObject[] clients = GameObject.FindGameObjectsWithTag("EighthNote");
		foreach (GameObject client in clients) {
			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 10f/15f), new Vector2(1f/18f, 1f/15f), Vector3.zero, false);
		
			// Set up standing animation
			UVAnimation sAnim = new UVAnimation();
			sAnim.name = "EighthNote Standing Animation";
			sAnim.loopCycles = -1;
			sAnim.framerate = 24;
			
			sAnim.BuildUVAnim(new Vector2(0f, 10f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
			
			// Prepare sprite
			clientSprite.AddAnimation(sAnim);
			
//			// Set up moving animation
//			UVAnimation mAnim = new UVAnimation();
//			mAnim.name = "EighthNote Moving Animation";
//			mAnim.loopCycles = -1;
//			mAnim.framerate = 24;
//			
//			mAnim.BuildUVAnim(new Vector2(0f, 9f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
//			
//			// Prepare sprite
//			clientSprite.AddAnimation(mAnim);
			
			clientSprite.PlayAnim("EighthNote Standing Animation");
		}
	}
}
