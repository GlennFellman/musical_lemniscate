using UnityEngine;
using System.Collections;

public class Level1_GuiTextManager : MonoBehaviour {
	private bool display_message = true;
	
	
	// Use this for initialization
	void Start () {
		print ("Level1 gui manager text active");
		display_message = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			display_message = false;
		}
	
	}
	
	
	void OnGUI () {
		if(display_message){
			print ("display message is true");
			// Make a background box
			GUI.Box(new Rect(100,10,350,90), "Be sure to protect your musical note from quarter rests. \n They don't want your note reach its spot on the staff. ");
		}
	}
}
	
	

