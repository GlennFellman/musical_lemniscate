using UnityEngine;
using System.Collections;

public class Modifier : MonoBehaviour
{
	public float enemySpeed;
	public bool isMovingRight;
	
	// Use this for initialization
	public virtual void Start ()
	{
		isMovingRight = true;
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(s, 0f, 0f);
	}
	
	public virtual void OnTriggerEnter(Collider collider)
	{
		Player p = GameObject.FindObjectOfType(typeof(Player)) as Player;
		if (collider.attachedRigidbody == p.rigidbody)
			this.active = false;
		else
			isMovingRight = !isMovingRight;
	}
	
	void 
}
