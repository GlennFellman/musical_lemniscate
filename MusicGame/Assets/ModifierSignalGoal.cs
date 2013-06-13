using UnityEngine;
using System.Collections;

public class ModifierSignalGoal : MonoBehaviour {
	
	public GameConstants.Modifiers myMod;
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
	public void changeMaterial(GameConstants.Modifiers newMod) {
		if (newMod != GameConstants.Modifiers.Flat && newMod != GameConstants.Modifiers.Sharp) {
			print("Error in changeMaterial call.");
			return;
		}
		
		// Set natural to modifier
		if (myMod == GameConstants.Modifiers.Natural)
			myMod = newMod;
		// Set modifier to natural
		else if (myMod != newMod)
			myMod = GameConstants.Modifiers.Natural;
	
		setMat();
	}
	
	public void setMat() {
		switch(myMod) {
		case GameConstants.Modifiers.Flat:
			renderer.material = flatMat;
			renderer.enabled = true;
			break;
		case GameConstants.Modifiers.Natural:
			renderer.enabled = false;
			break;
		case GameConstants.Modifiers.Sharp:
			renderer.material = sharpMat;
			renderer.enabled = true;
			break;
		default:
			break;
		}
	}
				
				
}
