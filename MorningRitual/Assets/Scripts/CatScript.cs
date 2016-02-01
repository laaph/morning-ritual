using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {
	public int gameTime = 2;
	bool catPet = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() { 
		GameManager.Instance.AddGameTime (gameTime);
		if(!catPet) {
			GameManager.Instance.ShowMessage("Oh what a cute kitten!");
			GameManager.Instance.AwardPoints(50, this.transform.position);
			catPet = true;
		} else {
			GameManager.Instance.ShowMessage("I can't stay here petting the cat all\n day, I have to go to work!");
			GameManager.Instance.AwardPoints(-10, this.transform.position);
		}

	}

}
