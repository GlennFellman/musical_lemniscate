using UnityEngine;
using System.Collections;

public class EighthRest : MonoBehaviour
{
	public float enemySpeed;
	public bool isMovingRight;
	
	public bool isOnTop;
	public GameConstants.Level level;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculate horizontal movement
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(0f, 0f, -s);
		
		// Calculate collisions with player
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;

		if(Mathf.Abs(transform.position.z - player.transform.position.z) < 1.5f && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.1f)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	public void warp()
	{
		if(level == GameConstants.Level.Four)
		{
			if(isOnTop)
				transform.Translate(0f, -9*GameConstants.DELTALAYER, 0f);
			else
				transform.Translate(0f, 3*GameConstants.DELTALAYER, 0f);
			isOnTop = !isOnTop;
			level = GameConstants.Level.One;
		}
		else
		{
			transform.Translate(0f, GameConstants.DELTALAYER, 0f);
			level++;
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "wall")
		{
			isMovingRight = !isMovingRight;
			
			// Translate away from wall
			if (!isMovingRight)
				transform.Translate(0f, 0f, 0.5f);
			else
				transform.Translate(0f, 0f, -0.5f);
			
			warp();
			changeAnim();
		}
	}
	
	void changeAnim() {
		LinkedSpriteManager lsm = GameObject.FindObjectOfType(typeof(LinkedSpriteManager)) as LinkedSpriteManager;
		lsm.changeDir(this.transform, isMovingRight);
	}
}
