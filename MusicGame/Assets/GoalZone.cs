using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	public void goalReached() {
		renderer.material.color = Color.green;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="follower"){
			goalReached();
		}
	}

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

}


