using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class BackgroundMusic : MonoBehaviour {
	
	public AudioSource bgMusic;
	
	public AudioClip topSlow;
	public AudioClip topFast;
	public AudioClip bottomSlow;
	public AudioClip bottomFast;
	
	private int currTime;
	
	// Use this for initialization
	void Start () {
		if (bgMusic == null) {
			bgMusic = gameObject.AddComponent<AudioSource>();
			bgMusic.loop = true;
			bgMusic.playOnAwake = false;
			bgMusic.pitch = 1.0f;
			//bgMusic.pitch = 1.0f * Mathf.Pow(2.0f, 0.25f); // Put song in Eb
			setMusic(); 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Sets the music that is playing based on clef and follower
	// This is called from player   (when warped)
	//                from follower (when following toggled)
	public void setMusic() {
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		//FollowerMove follower = player.getCurrentFollower();
		//bool sameLevel = (player.isOnTop == follower.isOnTop);
		
		if (bgMusic == null)
			Start ();
		currTime = bgMusic.timeSamples;
		AudioClip newClip;
		
		if (player.isOnTop) {
			if (player.isFastMusic)
				newClip = topFast;
			else
				newClip = topSlow;
		}
		else {
			if (player.isFastMusic)
				newClip = bottomFast;
			else
				newClip = bottomSlow;
		}
		
		if (bgMusic.clip != newClip) {
			bgMusic.clip = newClip;
			bgMusic.timeSamples = currTime;
			bgMusic.Play();
		}
	}
}
