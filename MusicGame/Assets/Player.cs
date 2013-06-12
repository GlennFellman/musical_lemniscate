using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public bool isOnTop;
	public GameConstants.Level level;

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
		
		audio.playOnAwake = false;
		audio.volume = 0.25f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 playerPosition = transform.position;
		
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			rigidbody.AddForce(0f, 0f, -4f, ForceMode.VelocityChange);
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			rigidbody.AddForce(0f, 0f, 4f, ForceMode.VelocityChange);
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if(level != GameConstants.Level.One)
			{
				playerPosition.y -= GameConstants.DELTALAYER;
				level--;
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if(level != GameConstants.Level.Four)
			{
				playerPosition.y += GameConstants.DELTALAYER;
				level++;
			}
		}
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
			
			// Change background music
			BackgroundMusic bgm = GameObject.FindObjectOfType(typeof(BackgroundMusic)) as BackgroundMusic;
			bgm.setMusic();
			
			// Play warp sound
			audio.Play();
		}
		
		playerPosition.x = 10.0f;
		transform.position = playerPosition;
	}
}
