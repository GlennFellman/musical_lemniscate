using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour {
	public void goalReached() {
		renderer.material.color = Color.green;
	}
}
