using UnityEngine;
using System.Collections;

public class SharpAnim : MonoBehaviour {
	
	public LinkedSpriteManager spriteManager;
	
	// Use this for initialization
	void Start () {
		DrawSharpAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DrawSharpAnimation() {
		// Put sprite on client objects
		GameObject[] clients = GameObject.FindGameObjectsWithTag("Sharp");
//		Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, spriteManager.PixelCoordToUVCoord(new Vector2(0f, 0f)), spriteManager.PixelSpaceToUVSpace(new Vector2(125f, 125f)), Vector3.zero, false);
		foreach (GameObject client in clients) {
//			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 2f/3f), new Vector2(1f/6f, 1f/3f), Vector3.zero, false);
			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 5f/15f), new Vector2(1f/18f, 1f/15f), Vector3.zero, false);
		
		
			// Set up animation
			UVAnimation anim = new UVAnimation();
			anim.name = "Sharp Animation";
			anim.loopCycles = -1;
			anim.framerate = 24;
			
	//		sharpAnim.BuildUVAnim(spriteManager.PixelCoordToUVCoord(new Vector2(0f, 0f)), spriteManager.PixelSpaceToUVSpace(new Vector2(125f, 125f)), 6, 3, 18, 24);
			anim.BuildUVAnim(new Vector2(0f, 5f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
			
			// Prepare sprite
			clientSprite.AddAnimation(anim);
			clientSprite.PlayAnim("Sharp Animation");
		}
	}
}
