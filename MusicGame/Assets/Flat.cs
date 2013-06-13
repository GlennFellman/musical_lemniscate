using UnityEngine;
using System.Collections;

public class Flat : Modifier {
	public override void changeModifierSignal(GameObject obj) {
		ModifierSignal ms = obj.GetComponentInChildren(typeof(ModifierSignal)) as ModifierSignal;
		ms.changeMaterial(GameConstants.Modifiers.Flat);
	}
}
