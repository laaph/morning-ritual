using UnityEngine;
using System.Collections;

public class Newspaper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GameManager.Instance.pickedUpNewspaper = true;
		GameManager.Instance.ShowMessage("I much prefer the newspaper to the\nradio or telly");
		GameManager.Instance.AwardPoints(10, transform.position);
		gameObject.SetActive(false);
	}
}
