using UnityEngine;
using System.Collections;

public class FollowerMove : MonoBehaviour
{
	public GameConstants.Notes note_type;
	
	public bool isOnTop;
	
	public bool isFollower;
	public bool isFollowing;
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
//		myColor = renderer.material.color;
//		renderer.material = matNotClose;
		
		// Sets materials according to note type
		switch(note_type)
		{
		case GameConstants.Notes.Quarter:
			// Set quarter material
			followerSpeed = 6;
			break;
		case GameConstants.Notes.Whole:
			// Set whole material
			followerSpeed = 3;
			break;
		case GameConstants.Notes.Eighth:
			// Set eigth material
			followerSpeed = 7;
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		// Find distance from follower to player
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		Vector3 playerPosition = player.transform.position;
		playerPosition.y += 0.05f; // For adjustment purposes
		Vector3 distance = playerPosition - this.transform.position;
		
		// Moves up if follower is an eight note
		GameObject[] floors = GameObject.FindGameObjectsWithTag("floor");
		if(note_type == GameConstants.Notes.Eighth && Mathf.Abs(distance.y) > 0.01 && player.isOnTop == this.isOnTop && player.followingOn && isFollower)
		{
			foreach(GameObject f in floors)
				Physics.IgnoreCollision(collider, f.collider);
			Vector3 newPosition = transform.position;
			newPosition.y += distance.y*followerSpeed*Time.deltaTime;
			transform.position = newPosition;
		}
		else if(!isFollowing || player.isOnTop != this.isOnTop)
		{
			foreach(GameObject f in floors)
				Physics.IgnoreCollision(collider, f.collider, false);
		}
		
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
		
		// Follow stuff
		if(Input.GetKeyDown(KeyCode.F)) {
//			isFollowing = !isFollowing;
//			
//			BackgroundMusic bgm = GameObject.FindObjectOfType(typeof(BackgroundMusic)) as BackgroundMusic;
//			bgm.setMusic();
		}
		if(player.followingOn && player.isOnTop == isOnTop && isFollower)
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
				followerPosition.y -= GameConstants.TOPLAYER;
			}
			else
			{
				followerPosition.y += GameConstants.TOPLAYER;
			}
			transform.position = followerPosition;
			isOnTop = !isOnTop;
		}
	}
	
	public void startFollowing() {
		isFollower = true;
		
		if (note_type == GameConstants.Notes.Eighth) {
			EighthNoteAnim anim = this.gameObject.GetComponent(typeof(EighthNoteAnim)) as EighthNoteAnim;
			anim.playMovingAnim();
		}
	}
	
	public void stopFollowing() {
		isFollower = false;
		
		if (note_type == GameConstants.Notes.Eighth) {
			EighthNoteAnim anim = this.gameObject.GetComponent(typeof(EighthNoteAnim)) as EighthNoteAnim;
			anim.playStandingAnim();
		}
	}
}
