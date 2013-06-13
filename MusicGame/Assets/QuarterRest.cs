using UnityEngine;
using System.Collections;

public class QuarterRest : MonoBehaviour
{
	private const float TOPLAYER = 9.6f;
	private const float BOTTOMLAYER = 0.0f;
	
	public float enemySpeed;
	public bool isMovingRight;
	
	public bool justWarped;
	public bool isOnTop;
	public bool wasCloseToPlayer;
	private bool closeToPlayer;
	private Color myColor;
	public Material matNotClose;
	public Material matClose;
	
	// Use this for initialization
	void Start ()
	{
		justWarped = false;
		wasCloseToPlayer = false;
		closeToPlayer = false;
		//renderer.material = matNotClose;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculate horizontal movement
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(0f, 0f, -s);
		
		// Calculate collisions with followers
		GameObject[] followers = GameObject.FindGameObjectsWithTag("follower");
		foreach(GameObject follower in followers)
		{
			if(Mathf.Abs(transform.position.z - follower.transform.position.z) < 1.5f && Mathf.Abs(transform.position.y - follower.transform.position.y) < 0.1f)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
		// Find distance from follower to player
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		Vector3 playerPosition = player.transform.position;
		Vector3 distance = playerPosition - this.transform.position;
		
		// Warp stuff
		if (distance.z > -1.4f && distance.z < 1.4f && distance.y > -0.5f && distance.y < 0.5f) {
			closeToPlayer = true;
    		//renderer.material.color = Color.yellow;
			//renderer.material = matClose;
		}
		else {
			closeToPlayer = false;
			//renderer.material.color = myColor;
			//renderer.material = matNotClose;
		}
		if(wasCloseToPlayer==true && closeToPlayer==false){
			justWarped=false;
		}
		wasCloseToPlayer = closeToPlayer;
	}
	
	public void warp() {
		if (closeToPlayer) {
			Vector3 followerPosition = transform.position;
			if(isOnTop && justWarped == false)
			{
				followerPosition.y -= TOPLAYER;
				isOnTop = false;
				justWarped = true;
			}
			else if(!isOnTop && justWarped == false)
			{
				followerPosition.y += TOPLAYER;
				isOnTop = true;
				justWarped = true;
			}
			transform.position = followerPosition;

		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "wall") {
			isMovingRight = !isMovingRight;
			changeAnim();
		}
	}
	
	void changeAnim() {
		LinkedSpriteManager lsm = GameObject.FindObjectOfType(typeof(LinkedSpriteManager)) as LinkedSpriteManager;
		lsm.changeDir(this.transform, isMovingRight);
	}
}
