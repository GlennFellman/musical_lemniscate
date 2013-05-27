using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warp : MonoBehaviour {
	
	//public AudioClip timeTravelSoundEffect;
	//public AudioClip unableToWarpSoundEffect;
	
	public float newline;
	public bool warpdirection;
	
	public const float TREBLE_F_SPACE = 0f;
	public const float TREBLE_D_SPACE = -4.5f;
	public const float TREBLE_B_SPACE = -6f;
	public const float TREBLE_G_SPACE = -7.4f;
	public const float TREBLE_E_SPACE = -2.6f;
	
	public const float BASS_A_SPACE = 0f;
	public const float BASS_F_SPACE = 3.5f;
	public const float BASS_D_SPACE = 2f;
	public const float BASS_B_SPACE = 5.3f;
	public const float BASS_G_SPACE = 3.5f;
	
	public const float TREBLE_F_LINE = -2.5f;
	public const float TREBLE_D_LINE = -4.5f;
	public const float TREBLE_B_LINE = -5.9f;
	public const float TREBLE_G_LINE = -7.6f;
	public const float TREBLE_E_LINE = -4.3f;
	
	public const float BASS_A_LINE = 3.5f;
	public const float BASS_F_LINE = 8.5f;
	public const float BASS_D_LINE = 6.6f;
	public const float BASS_B_LINE = 5.3f;
	public const float BASS_G_LINE = 3.5f;
	
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Input.GetKeyDown(KeyCode.O))
		
			{
				warpdirection=true;
				newline=getmusicline();
				Vector3 pos = transform.position;
				pos.y = newline;
				if(newline!=0)
					transform.position = pos;
										
			}
			
		if(Input.GetKeyDown(KeyCode.L))
		
			{
				warpdirection=false;
				newline=getmusicline();
				Vector3 pos = transform.position;
				pos.y = newline;
				if(newline!=0)
					transform.position = pos;
												
			}
		

	/*			if(audio.isPlaying)
					audio.Stop();
				audio.PlayOneShot(timeTravelSoundEffect);
			}
			else
			{
				if(audio.isPlaying)
						audio.Stop();
					audio.PlayOneShot(unableToWarpSoundEffect);
			}
			
	*/
		
	}
	
float getmusicline(){
	Vector3 currentLine=transform.position;
	if(warpdirection){
		if (currentLine.y > 1.7 && currentLine.y<3.2)
			return TREBLE_E_SPACE;
		else if (currentLine.y > 3.2 && currentLine.y<4.8)
			return TREBLE_G_SPACE;
		else if (currentLine.y > 4.8 && currentLine.y<6.4)
			return TREBLE_B_SPACE;
		else if (currentLine.y > 6.4 && currentLine.y<8)
			return TREBLE_D_SPACE;
		else if (currentLine.y > 8)
			return TREBLE_F_SPACE;
		else if (currentLine.y < -1.6 && currentLine.y > -3.1)
			return BASS_F_SPACE;
		else if (currentLine.y < -3.1 && currentLine.y > -4.8)
			return BASS_D_SPACE;
		else if (currentLine.y < -4.8 && currentLine.y > -6.3)
			return BASS_B_SPACE;
		else if (currentLine.y < -6.3 && currentLine.y > -8)
			return BASS_G_SPACE;
		else
			return BASS_A_SPACE;
	}

else{
		if (currentLine.y > 1.7 && currentLine.y<3.2)
			return TREBLE_E_LINE;
		else if (currentLine.y > 3.2 && currentLine.y<4.8)
			return TREBLE_G_LINE;
		else if (currentLine.y > 4.8 && currentLine.y<6.4)
			return TREBLE_B_LINE;
		else if (currentLine.y > 6.4 && currentLine.y<8)
			return TREBLE_D_LINE;
		else if (currentLine.y > 8)
			return TREBLE_F_LINE;
		else if (currentLine.y < -1.6 && currentLine.y > -3.1)
			return BASS_F_LINE;
		else if (currentLine.y < -3.1 && currentLine.y > -4.8)
			return BASS_D_LINE;
		else if (currentLine.y < -4.8 && currentLine.y > -6.3)
			return BASS_B_LINE;
		else if (currentLine.y < -6.3 && currentLine.y > -8)
			return BASS_G_LINE;
		else
			return BASS_A_LINE;
		
	}

}
	
}

	
/*
	bool CanWarp()
	{
		Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));
		Vector3 newPosition = transform.position;
		newPosition.y = isOnLowerLevel? newPosition.y+400 : newPosition.y-400;
		
		foreach(Object obj in objects)
		{
			try{
				if(((GameObject) obj).activeInHierarchy && ((GameObject) obj).collider.bounds.Contains(newPosition))
				{
					//FlashWhenHit();
					return false;
				}
			}catch{}
		}
		
		return true;
	}
		

	void Fade(float start, float end, float length, GameObject currentObject)
	{
		if (currentObject.guiTexture.color.a == start)
		{
			for (float i = 0.0F; i < 1.0F; i += Time.deltaTime*(1/length))
			{
				Color tempColor = currentObject.guiTexture.color;
				tempColor.a = Mathf.Lerp(start, end, i);
				currentObject.guiTexture.color = tempColor;
				tempColor.a = end;
				currentObject.guiTexture.color = tempColor;
			}
		}
	}
	
	void FlashWhenHit()
	{
		Fade(0F, 0.8F, 0.5F, GameObject.Find("Red"));
		System.Threading.Thread.Sleep(100);
		Fade(0.8F, 0F, 0.5F, GameObject.Find("Red"));
    }
}
*/