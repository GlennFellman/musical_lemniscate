using UnityEngine;
using System.Collections;

public class FollowerMove : MonoBehaviour
{
	private const float TOPLAYER = 9.6f;
	private const float BOTTOMLAYER = 0.0f;
	
	public bool isOnTop;
	
	private bool isFollowing;
	public int followerSpeed;
	private bool closeToPlayer;
	private Color myColor;
	public Material matNotClose;
	public Material matClose;

	// Use this for initialization
	void Start ()
	{
		isFollowing = false;
		closeToPlayer = false;
		myColor = renderer.material.color;
		renderer.material = matNotClose;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		// Find distance from follower to player
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		Vector3 playerPosition = player.transform.position;
		Vector3 distance = playerPosition - this.transform.position;
		
		// Warp stuff
		if (distance.z > -1.4f && distance.z < 1.4f && distance.y > -0.5f && distance.y < 0.5f) {
			closeToPlayer = true;
    		renderer.material.color = Color.yellow;
			//renderer.material = matClose;
		}
		else {
			closeToPlayer = false;
			//renderer.material.color = myColor;
			renderer.material = matNotClose;
			
		}
		
		// Follow stuff
		if(Input.GetKeyDown(KeyCode.F))
			isFollowing = !isFollowing;
		if(isFollowing && player.isOnTop == isOnTop)
		{
			Vector3 translation = Vector3.Normalize(distance)*Time.deltaTime*followerSpeed;
			if(distance.z > 1.4f || distance.z < -1.4f){
				this.transform.Translate(0, 0, translation.z);
			}
//			if (distance.z > 1.5f)
//				rigidbody.AddForce(0f, 0f, -100f, ForceMode.VelocityChange);
//			else if (distance.z < 1.5f)
//				rigidbody.AddForce(0f, 0f, 100f, ForceMode.VelocityChange);
		}
	}
	
	public void warp() {
		if (closeToPlayer) {
			Vector3 followerPosition = transform.position;
			if(isOnTop)
			{
				followerPosition.y -= TOPLAYER;
			}
			else
			{
				followerPosition.y += TOPLAYER;
			}
			transform.position = followerPosition;
			isOnTop = !isOnTop;
		}
	}
	

}
