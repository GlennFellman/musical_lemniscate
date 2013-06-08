using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	
	public GameObject modifier_sig;
	public Material sharp_mat;
	public Material flat_mat;
	public AudioClip bad_mod;
	//bool soundOn = true;
	
	public void goalReached() {
		//Check to see if the player's modifier signal has acquired the color of the sharp (blue). If so, win!
		if(modifier_sig.renderer.material.color==flat_mat.color){
			renderer.material.color = Color.green;
			Application.LoadLevel(Application.loadedLevel+1);
		}else{ //Else, play error audio
			//if(soundOn==true){
				audio.Play();
				//soundOn=false;
			}
	}
	
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag=="follower"){	
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


