using UnityEngine;
using System.Collections;

public class ModifierSignal : MonoBehaviour {
	
	// The starting modifier value
	//   -1 is flat
	//    0 is natural
	//    1 is sharp
	public int myMod;
	public Material flatMat;
	public Material sharpMat;
	
	// Use this for initialization
	void Start () {
		setMat();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Change the material.
	public void changeMaterial(int newMod) {
		if (newMod != -1 && newMod != 1) {
			print("Error in changeMaterial call.");
			return;
		}
		
		// Set natural to modifier
		if (myMod == 0)
			myMod = newMod;
		// Set modifier to natural
		else if (myMod != newMod)
			myMod = 0;
	
		setMat();
	}
	
	void setMat() {
		switch(myMod) {
		case -1:
			renderer.material = flatMat;
			renderer.enabled = true;
			break;
		case 0:
			renderer.enabled = false;
			break;
		case 1:
			renderer.material = sharpMat;
			renderer.enabled = true;
			break;
		default:
			break;
		}
	}
				
				
}
