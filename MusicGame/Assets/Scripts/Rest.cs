using UnityEngine;
using System.Collections;

// FOR BOTH WHOLE AND HALF RESTS

public class Rest : MonoBehaviour
{
	private bool canWarp;
	public GameConstants.Rests restType;

	// Use this for initialization
	void Start ()
	{
		canWarp = true;
		
		// Set textures according to type
		switch(restType)
		{
		case GameConstants.Rests.Half:
			// Set half rest texture
			break;
		case GameConstants.Rests.Whole:
			// Set whole rest texture
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		FollowerMove[] followers = GameObject.FindObjectsOfType(typeof(FollowerMove)) as FollowerMove[];
		foreach(FollowerMove follower in followers)
		{
			Vector3 followerPos = follower.transform.position;
			Vector3 restPos = this.transform.position;
			/*if(follower.note_type == GameConstants.Notes.Whole)
			{
				if(Mathf.Abs(restPos.z - followerPos.z) < 1 && Mathf.Abs(restPos.y - followerPos.y) < 0.1)
					canWarp = false;
				else
					canWarp = true;
			}*/
			//else // if note_type is Quarter or Eighth note
			//{
				if(restType == GameConstants.Rests.Whole)
					restPos.y += 1.6f;
				if(canWarp && Mathf.Abs(restPos.z - followerPos.z) < 0.1 && Mathf.Abs(restPos.y - followerPos.y) < 0.1)
				{
					followerPos.y += GameConstants.DELTALAYER*((int) restType);
					follower.transform.position = followerPos;
				}
			//}
		}
	}
}
