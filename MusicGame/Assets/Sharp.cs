using UnityEngine;
using System.Collections;

public class Sharp : Modifier {
	public override void changeModifierSignal() {
		ModifierSignal ms = GameObject.FindObjectOfType(typeof(ModifierSignal)) as ModifierSignal;
		ms.changeMaterial(1);
	}
}
