using UnityEngine;
using System.Collections;

public class Clothes : MonoBehaviour {

	public Sprite newClothes;
	public int gameTime = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GameObject g = GameObject.FindGameObjectWithTag("Player");
		SpriteRenderer r = g.GetComponentInChildren<SpriteRenderer>();
		r.sprite = newClothes;
		if(GameManager.Instance.tookShower) {
			GameManager.Instance.AwardPoints(50, this.transform.position);
			GameManager.Instance.ShowMessage("Yay clean clothes!");
		} else {
			GameManager.Instance.ShowMessage("I should have taken a shower first.");
			GameManager.Instance.AwardPoints(30, this.transform.position);
		}
		GameManager.Instance.AddGameTime (gameTime);
		gameObject.SetActive(false);
	}
}
