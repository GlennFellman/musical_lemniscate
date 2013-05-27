using UnityEngine;
using System.Collections;

public class PlantSeed : MonoBehaviour
{
	
	public AudioClip plantSoundEffect;
	public AudioClip unableToPlantSoundEffect;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject player = GameObject.Find("Player");
		if(Input.GetKeyDown(KeyCode.Z))
		{
			PlantTree();
		}
	}
	
	void PlantTree()
	{
		Vector3 playerPosition, plantPosition;
		playerPosition = plantPosition = GameObject.Find("Player").transform.position;
		playerPosition.y -= 0.9963f;
		plantPosition.y = playerPosition.y<0.3f? 0.0f : 400.0f;
		if(playerPosition.y < 0.3f || (playerPosition.y > 400f && playerPosition.y < 400.3f))
		{
			GameObject seed = (GameObject) Instantiate(Resources.Load("Seed"), plantPosition, Quaternion.identity);
			seed.transform.localScale = new Vector3(0.05f, 0.08f, 0.05f);
			
			if(audio.isPlaying)
				audio.Stop();
			audio.PlayOneShot(plantSoundEffect);
		}
		else
		{
			if(audio.isPlaying)
				audio.Stop();
			audio.PlayOneShot(unableToPlantSoundEffect);
		}
		if(playerPosition.y < 0.3f)
		{
			plantPosition.y += 400f; plantPosition.z = 1.5f;
			GameObject tree = (GameObject) Instantiate(Resources.Load("Tree/Trees/Tree"), plantPosition, Quaternion.identity);
		}
	}
}