using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	public void goalReached() {
		renderer.material.color = Color.green;
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


