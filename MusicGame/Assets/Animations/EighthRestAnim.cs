using UnityEngine;
using System.Collections;

public class EighthRestAnim : MonoBehaviour {
	
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
		GameObject[] clients = GameObject.FindGameObjectsWithTag("EighthRest");
		foreach (GameObject client in clients) {
			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 12f/15f), new Vector2(1f/18f, 1f/15f), Vector3.zero, false);
		
		
			// Set up left animation
			UVAnimation lAnim = new UVAnimation();
			lAnim.name = "EighthRest Left Animation";
			lAnim.loopCycles = -1;
			lAnim.framerate = 24;
			
			lAnim.BuildUVAnim(new Vector2(0f, 12f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
			
			// Prepare sprite
			clientSprite.AddAnimation(lAnim);

			
			// Set up right animation
			UVAnimation rAnim = new UVAnimation();
			rAnim.name = "EighthRest Right Animation";
			rAnim.loopCycles = -1;
			rAnim.framerate = 24;
			
			rAnim.BuildUVAnim(new Vector2(0f, 11f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
			
			// Prepare sprite
			clientSprite.AddAnimation(rAnim);
			
			// Starting direction
			EighthRest er = client.GetComponent(typeof(EighthRest)) as EighthRest;
			if (er.isMovingRight)
				clientSprite.PlayAnim("EighthRest Right Animation");
			else
				clientSprite.PlayAnim("EighthRest Left Animation");
		}
	}
}
