using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) Application.LoadLevel(Application.loadedLevel+1);
	}

	/*void OnGui() {
		alpha = Mathf.Lerp(alpha, 1, 0.1f * Time.deltaTime);
		guiTexture.color = new Color(1,1,1, alpha);
	}*/
	
	/*IEnumerator FadeCoroutine(){
		StartCoroutine(FadeIn(texture));
		
	}*/
}

