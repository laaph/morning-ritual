using UnityEngine;
using System.Collections;
public int gameTime = 4;

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
		GameManager.Instance.AddGameTime (gameTime);
	}
}
