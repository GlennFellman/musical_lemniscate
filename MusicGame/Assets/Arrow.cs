using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		setPosition();
	}
	
	// Update is called once per frame
	void Update () {
		setPosition();
	}
	
	void setPosition() {
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		FollowerMove follower = player.getCurrentFollower();
		Vector3 newPos = follower.transform.position;
		newPos.y += 0.3f;
		this.transform.position = newPos;
	}
}
