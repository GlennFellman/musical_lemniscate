using UnityEngine;
using System.Collections;

public class NoteSignalGoal : MonoBehaviour {
	
	public GameConstants.Notes myNote;
	public Material wholeMat;
	public Material quarterMat;
	public Material eighthMat;
	
	// Use this for initialization
	void Start () {
		renderer.enabled = true;
		setMat();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setMat() {
		switch(myNote) {
		case GameConstants.Notes.Whole:
			renderer.material = wholeMat;
			break;
		case GameConstants.Notes.Quarter:
			renderer.material = quarterMat;
			break;
		case GameConstants.Notes.Eighth:
			renderer.material = eighthMat;
			break;
		default:
			break;
		}
	}
				
				
}
