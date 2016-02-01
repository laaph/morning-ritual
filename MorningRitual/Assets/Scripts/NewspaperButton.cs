using UnityEngine;
using System.Collections;

public class NewspaperButton : MonoBehaviour {
	public GameObject newspaperLate;
	public GameObject newspaperCoffee;

	// Use this for initialization
	void Start () {
		if (!this.newspaperLate) {
			Debug.LogError("NewspaperButton missing late article");
		}
		if (!this.newspaperCoffee) {
			Debug.LogError("NewspaperButton missing coffee article");
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		if(GameManager.Instance.hadCoffee) {
			newspaperLate.SetActive(true);
		} else {
			newspaperCoffee.SetActive(true);
		}
		gameObject.SetActive(false);
	}

}
