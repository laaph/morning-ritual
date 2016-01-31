using UnityEngine;
using System.Collections;

public class CoffeePot : MonoBehaviour {
	public Mug mug;

	void Start() {
		if (!mug) {
			Debug.LogError("Coffee pot is not connected to mug");
		}
	}

	void OnMouseDown() {
		if (!mug) {
			return;
		}
		mug.AddCoffee();
	}
}
