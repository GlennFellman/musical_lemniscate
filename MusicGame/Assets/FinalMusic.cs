using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class FinalMusic : MonoBehaviour {
	
	public AudioSource bgMusic;
	
	public AudioClip myAudio;
	
	// Use this for initialization
	void Start () {
		if (bgMusic == null) {
			bgMusic = gameObject.AddComponent<AudioSource>();
			bgMusic.loop = true;
			bgMusic.playOnAwake = true;
			bgMusic.pitch = 1.0f * Mathf.Pow(2.0f, 0.25f); // Put song in Eb
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
