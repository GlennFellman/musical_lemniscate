using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	public float enemySpeed;
	public bool isMovingRight;
	
	// Use this for initialization
	void Start ()
	{
		isMovingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(s, 0f, 0f);
	}
	
	void OnTriggerEnter(Collider collider)
	{
		print (3);
	}
}
