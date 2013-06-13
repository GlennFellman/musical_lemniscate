using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public bool isOnTop;
	public GameConstants.Level level;
	public FollowerMove[] followers;
	public int currFollowerInt;
	public bool followingOn;
	public bool isFastMusic;

	// Use this for initialization
	void Start ()
	{
		Vector3 playerPosition = transform.position;
		playerPosition.x = 10.0f;
		playerPosition.y = GameConstants.PLATFORMHEIGHT;
		playerPosition.y += isOnTop? GameConstants.TOPLAYER : GameConstants.BOTTOMLAYER;
		playerPosition.y += GameConstants.DELTALAYER*((int) level-1);
		playerPosition.z = 13.0f;
		transform.position = playerPosition;
		
		// Followers setup
		followers = GameObject.FindObjectsOfType(typeof(FollowerMove)) as FollowerMove[];
		currFollowerInt = 0;
		followers[currFollowerInt].startFollowing();
		
		// Music setup
		audio.playOnAwake = false;
		audio.volume = 0.25f;
		changeBackgroundMusic();
		
		// Animation setup
		changeAnimations();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 playerPosition = transform.position;
		
		// Move left/right
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			rigidbody.AddForce(0f, 0f, -4f, ForceMode.VelocityChange);
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			rigidbody.AddForce(0f, 0f, 4f, ForceMode.VelocityChange);
		
		// Jump down
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if(level != GameConstants.Level.One)
			{
				playerPosition.y -= GameConstants.DELTALAYER;
				level--;
			}
		}
		
		// Jump up
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if(level != GameConstants.Level.Four)
			{
				playerPosition.y += GameConstants.DELTALAYER;
				level++;
			}
		}
		
		// Warp
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(isOnTop)
			{
				playerPosition.y -= GameConstants.TOPLAYER;
			}
			else
			{
				playerPosition.y += GameConstants.TOPLAYER;
			}
			isOnTop = !isOnTop;
			FollowerMove[] followers = GameObject.FindObjectsOfType(typeof(FollowerMove)) as FollowerMove[];
			foreach (FollowerMove f in followers)
				f.warp();
			QuarterRest[] enemies = GameObject.FindObjectsOfType(typeof(QuarterRest)) as QuarterRest[];
			foreach(QuarterRest qr in enemies)
				qr.warp();
			
			changeBackgroundMusic();
			
			// Play warp sound
			audio.Play();
		}
		
		// Toggle following
		if (Input.GetKeyDown(KeyCode.F)) {
			followingOn = !followingOn;
//			followers[currFollowerInt].changeAnimation(followingOn);
			
			changeBackgroundMusic();
		}
		
		// Change follower
		if (Input.GetKeyDown(KeyCode.G)) {
			// Remove current follower
			followers[currFollowerInt].stopFollowing();
//			if (followingOn)
//				followers[currFollowerInt].changeAnimation(false);
			
			// Make next follower follow
			currFollowerInt++;
			if (currFollowerInt >= followers.Length)
				currFollowerInt = 0;
			followers[currFollowerInt].startFollowing();
//			if (followingOn)
//				followers[currFollowerInt].changeAnimation(true);
			
			changeBackgroundMusic();
		}
		
		playerPosition.x = 10.0f;
		transform.position = playerPosition;
	}
	
	public FollowerMove getCurrentFollower() {
		return followers[currFollowerInt];	
	}
	
	// Change background music
	private void changeBackgroundMusic() {
		bool ifmChanged = setIsFastMusic();
		BackgroundMusic bgm = GameObject.FindObjectOfType(typeof(BackgroundMusic)) as BackgroundMusic;
		bgm.setMusic();
		
		// Change animations if framerate changed
		if (ifmChanged)
			changeAnimations();
	}
	
	// Change animations
	private void changeAnimations() {
		LinkedSpriteManager lsm = GameObject.FindObjectOfType(typeof(LinkedSpriteManager)) as LinkedSpriteManager;
		lsm.changeFrameRate();
	}
	
	private bool setIsFastMusic() {
		bool sameLevel = (isOnTop == followers[currFollowerInt].isOnTop);
		bool oldIFM = isFastMusic;
		
		if (sameLevel && followingOn)
			isFastMusic = true;
		else
			isFastMusic = false;
		
		// Return true if it changed, false if it didn't
		return (isFastMusic != oldIFM);
	}
}
