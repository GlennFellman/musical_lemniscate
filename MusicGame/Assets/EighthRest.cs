using UnityEngine;
using System.Collections;

public class EighthRest : MonoBehaviour
{
	private const float DELTALAYER = 1.6f;
	
	public float enemySpeed;
	public bool isMovingRight;
	
	public bool isOnTop;
	public int level;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculate horizontal movement
		float s = isMovingRight? enemySpeed : -enemySpeed;
		s *= Time.deltaTime;
		this.transform.Translate(0f, 0f, -s);
		
		// Calculate collisions with player
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;

		if(Mathf.Abs(transform.position.z - player.transform.position.z) < 1.5f && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.1f)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	public void warp()
	{
		if(level == 4)
		{
			if(isOnTop)
				transform.Translate(0f, -9*DELTALAYER, 0f);
			else
				transform.Translate(0f, 3*DELTALAYER, 0f);
			isOnTop = !isOnTop;
			level = 1;
		}
		else
		{
			transform.Translate(0f, DELTALAYER, 0f);
			level++;
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "wall")
		{
			isMovingRight = !isMovingRight;
			warp();
		}
	}
}
