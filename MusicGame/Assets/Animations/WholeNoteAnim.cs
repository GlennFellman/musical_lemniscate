using UnityEngine;
using System.Collections;

public class WholeNoteAnim : MonoBehaviour {
	
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
		GameObject[] clients = GameObject.FindGameObjectsWithTag("WholeNote");
		foreach (GameObject client in clients) {
			Sprite clientSprite = spriteManager.AddSprite(client, 1f, 1f, new Vector2(0f, 2f/15f), new Vector2(1f/18f, 1f/15f), Vector3.zero, false);
		
			// Set up animation
			UVAnimation anim = new UVAnimation();
			anim.name = "WholeNote Animation";
			anim.loopCycles = -1;
			anim.framerate = 24;
			
			anim.BuildUVAnim(new Vector2(0f, 2f/15f), new Vector2(1f/18f, 1f/15f), 18, 1, 18, 24);
			
			// Prepare sprite
			clientSprite.AddAnimation(anim);
			clientSprite.PlayAnim("WholeNote Animation");
		}
	}
}
