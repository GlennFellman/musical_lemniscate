using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour
{
	public enum Level { One = 1, Two = 2, Three = 3, Four = 4 }; // Yes I'm serious. Makes selection easier in Inspector.
	public enum Notes { Quarter = -1, Whole = 0, Eighth = 1 };
	public enum Rests { Whole = -1, Half = 1 };
	public enum EnemyRests { Quarter = 1, Eighth = 2 };
	public enum Modifiers { Sharp = 1, Natural = 0, Flat = -1 };
	
	public const float BOTTOMLAYER = 0.0f;
	public const float TOPLAYER = 9.6f;
	public const float DELTALAYER = 1.6f;
	public const float PLATFORMHEIGHT = 0.7882414f;
}
