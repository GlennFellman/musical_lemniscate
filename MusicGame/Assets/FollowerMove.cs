using UnityEngine;
using System.Collections;

public class FollowerMove : MonoBehaviour
{
	private bool isFollowing;
	public int followerSpeed;

	// Use this for initialization
	void Start ()
	{
		isFollowing = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.F))
			isFollowing = !isFollowing;
		if(isFollowing)
		{
			Vector3 playerPosition = GameObject.Find("Player").transform.position;
			Vector3 distance = playerPosition - this.transform.position;
			Vector3 translation = Vector3.Normalize(distance)*Time.deltaTime*followerSpeed;
			if(distance.z > 1.5f || distance.z < -1.5f)
				this.transform.Translate(0, 0, translation.z);
		}
	}
}
