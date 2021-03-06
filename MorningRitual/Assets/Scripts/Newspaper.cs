﻿using UnityEngine;
using System.Collections;

public class Newspaper : MonoBehaviour {

	public GameObject newspaperButton;
	public int gameTime = 5;
	// Use this for initialization
	void Start () {
		if (!this.newspaperButton) {
			Debug.LogError("Newspaper missing readme button");
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GameManager.Instance.pickedUpNewspaper = true;
		GameManager.Instance.ShowMessage("I much prefer the newspaper to the\nradio or telly");
		GameManager.Instance.AwardPoints(10, transform.position);
		GameManager.Instance.AddGameTime (gameTime);
		newspaperButton.SetActive(true);
		gameObject.SetActive(false);
	}
}
