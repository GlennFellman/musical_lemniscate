using UnityEngine;
using System.Collections;

public class Modifier : MonoBehaviour
{
	//public GameObject modifier_sig;
	public float enemySpeed;
	public bool isMovingRight;
	public Material mat;
	
	// Use this for initialization
	void Start ()
	{
		renderer.material = mat;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculate horizontal movement
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(0f, 0f, -s);	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "wall")
			isMovingRight = !isMovingRight;
		
		//GameObject follower = GameObject.Find("Follower");
		if (collider.gameObject.tag == "follower"){
			
			changeModifierSignal();
			
			// Old mod code
			//Active modifier signal
//			if (modifier_sig.activeSelf) {
//				// Make modifier signal natural
//				if (modifier_sig.renderer.material != this.renderer.material)
//					modifier_sig.SetActive(false);
//			}
//			// Non-active modifier signal
//			else {
//				modifier_sig.SetActive(true);
//				modifier_sig.renderer.material=this.renderer.material;
//			}
			//Destroy(this.gameObject);
		}		
	}
	
	public virtual void changeModifierSignal() {}
}
