using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	
	private ModifierSignal modifier_sig;
	private GameObject follower;
	public AudioClip bad_mod;
	public GameConstants.Modifiers req_mod;
	public GameConstants.Notes req_note_type;
	private GameConstants.Notes noteType;
	public bool reached = false;

	
	public void goalReached() {
		//Check to see if the player's modifier signal has acquired the color of the sharp (blue). If so, win!
		if(req_mod==modifier_sig.myMod && req_note_type == noteType){

			reached = true;
			
			// See if other goals reached
			bool allOthersReached = true;
			GoalZone[] goalzones = GameObject.FindObjectsOfType(typeof(GoalZone)) as GoalZone[];
			foreach (GoalZone goalzone in goalzones) {
				if (!goalzone.reached) {
					allOthersReached = false;
					break;
				}
			}

			if (allOthersReached)
				Application.LoadLevel(Application.loadedLevel+1);
			
			
		}else{ //Else, play error audio
				audio.Play();
			}
	}
	
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag=="QuarterNote" || collider.gameObject.tag=="WholeNote" || collider.gameObject.tag=="EighthNote"){
			
			FollowerMove follower = (FollowerMove) collider.gameObject.GetComponent("FollowerMove");
			noteType = follower.note_type;
			modifier_sig = collider.gameObject.GetComponentInChildren(typeof(ModifierSignal)) as ModifierSignal;
			goalReached();
		}
	}
	

	void Start ()
	{
		// Set modifier material
		ModifierSignalGoal msg = this.GetComponentInChildren(typeof(ModifierSignalGoal)) as ModifierSignalGoal;
		msg.myMod = req_mod;
		msg.setMat();
		
		// Set note material
		NoteSignalGoal nsg = this.GetComponentInChildren(typeof(NoteSignalGoal)) as NoteSignalGoal;
		nsg.myNote = req_note_type;
		nsg.setMat();
	}
	
	void Update ()
	{
		
	}

}


