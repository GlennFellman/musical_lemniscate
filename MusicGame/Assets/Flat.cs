using UnityEngine;
using System.Collections;

public class Flat : Modifier {
	public override void changeModifierSignal() {
		ModifierSignal ms = GameObject.FindObjectOfType(typeof(ModifierSignal)) as ModifierSignal;
		ms.changeMaterial(GameConstants.Modifiers.Flat);
	}
}
