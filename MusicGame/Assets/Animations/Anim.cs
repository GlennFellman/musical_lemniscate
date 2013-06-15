using UnityEngine;
using System.Collections;

public class Anim : MonoBehaviour {
	
	protected LinkedSpriteManager spriteManager;
	protected Sprite sprite;
	
	protected float numRows = 15f;
	protected float numCols = 18f;
	protected Vector2 cellSize;
	
	// Use this for initialization
	void Start () {
		cellSize = new Vector2(1f/numCols, 1f/numRows);
		
		spriteManager = GameObject.FindObjectOfType(typeof(LinkedSpriteManager)) as LinkedSpriteManager;
		createSprite();
		createAnimations();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	protected virtual void createSprite() {}
	protected virtual void createAnimations() {}
}
