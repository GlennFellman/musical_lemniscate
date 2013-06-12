using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	
	private ModifierSignal modifier_sig;
	private GameObject follower;
	private int collideID;
	public AudioClip bad_mod;
	public int req_mod;
	public int req_note_type;
	private int note_type;
	

	
	public void goalReached() {
		//Check to see if the player's modifier signal has acquired the color of the sharp (blue). If so, win!
		if(req_mod==modifier_sig.myMod && req_note_type == collideID){
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
			
			foreach (MonoBehaviour mb in (MonoBehaviour)collider.gameObject.GetComponents()) {
				print (mb is FollowerMove);
			}
			//print (collider.gameObject is FollowerMove);
			if (collider.gameObject is FollowerMove){
				collideID = 1;
			}
			
			follower = collider.gameObject;
			modifier_sig = collider.gameObject.GetComponentInChildren(typeof(ModifierSignal)) as ModifierSignal;
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


