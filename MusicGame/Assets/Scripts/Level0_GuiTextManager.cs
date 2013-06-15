using UnityEngine;
using System.Collections;

public class Level0_GuiTextManager : MonoBehaviour {
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
			GUI.Box(new Rect(175,10,300,90), "Bring your musical note home! \n Press Q to warp between the staffs. \n Press F to make your note follow you. \n\n (Press SPACE to remove messages like these)");
		}
	}
}
	
