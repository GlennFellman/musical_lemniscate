using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	
	private ModifierSignal modifier_sig;
	private GameObject follower;
	public AudioClip bad_mod;
	public GameConstants.Modifiers req_mod;
	public GameConstants.Notes req_note_type;
	private GameConstants.Notes noteType;
	

	
	public void goalReached() {
		//Check to see if the player's modifier signal has acquired the color of the sharp (blue). If so, win!
		if(req_mod==modifier_sig.myMod && req_note_type == noteType){
			renderer.material.color = Color.green;
			Application.LoadLevel(Application.loadedLevel+1);
		}else{ //Else, play error audio
			//if(soundOn==true){
				audio.Play();
			}
	}
	
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag=="follower"){
			
			FollowerMove follower = (FollowerMove) collider.gameObject.GetComponent("FollowerMove");
			noteType = follower.note_type;
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


