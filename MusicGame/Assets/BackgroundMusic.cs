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
		bgMusic = gameObject.AddComponent<AudioSource>();
		bgMusic.loop = true;
		bgMusic.playOnAwake = false;
		setMusic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Sets the music that is playing based on clef and follower
	// This is called from player   (when warped)
	//                from follower (when following toggled)
	public void setMusic() {
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		FollowerMove follower = GameObject.FindObjectOfType(typeof(FollowerMove)) as FollowerMove;
		bool sameLevel = (player.isOnTop == follower.isOnTop);
		
		currTime = bgMusic.timeSamples;
		AudioClip newClip;
		
		if (player.isOnTop) {
			if (follower.isFollowing && sameLevel)
				newClip = topFast;
			else
				newClip = topSlow;
		}
		else {
			if (follower.isFollowing && sameLevel)
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
