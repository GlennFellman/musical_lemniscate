using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public bool isOnTop;
	public int level;
	
	private const float BOTTOMLAYER = 0.0f;
	private const float TOPLAYER = 9.6f;
	private const float DELTALAYER = 1.6f;
	private const float PLATFORMHEIGHT = 0.7882414f;

	// Use this for initialization
	void Start ()
	{
		GameObject modifier_sig = GameObject.Find("Modifier_Sig");
		modifier_sig.SetActive(false);
		Vector3 playerPosition = transform.position;
		playerPosition.x = 10.0f;
		playerPosition.y = PLATFORMHEIGHT;
		playerPosition.y += isOnTop? TOPLAYER : BOTTOMLAYER;
		playerPosition.y += DELTALAYER*(level-1);
		playerPosition.z = 13.0f;
		transform.position = playerPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 playerPosition = transform.position;
		
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			rigidbody.AddForce(0f, 0f, -4f, ForceMode.VelocityChange);
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			rigidbody.AddForce(0f, 0f, 4f, ForceMode.VelocityChange);
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if(level != 1)
			{
				playerPosition.y -= DELTALAYER;
				level--;
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if(level != 4)
			{
				playerPosition.y += DELTALAYER;
				level++;
			}
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(isOnTop)
			{
				playerPosition.y -= TOPLAYER;
			}
			else
			{
				playerPosition.y += TOPLAYER;
			}
			isOnTop = !isOnTop;
			FollowerMove[] followers = GameObject.FindObjectsOfType(typeof(FollowerMove)) as FollowerMove[];
			foreach (FollowerMove f in followers)
				f.warp();
			QuarterRest[] enemies = GameObject.FindObjectsOfType(typeof(QuarterRest)) as QuarterRest[];
			foreach(QuarterRest qr in enemies)
				qr.warp();
		}
		
		playerPosition.x = 10.0f;
		transform.position = playerPosition;
	}
}
