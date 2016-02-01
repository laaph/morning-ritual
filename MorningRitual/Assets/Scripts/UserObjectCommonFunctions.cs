using UnityEngine;
using System.Collections;

public class UserObjectCommonFunctions : MonoBehaviour {
	Renderer rend;
	public Color glowColor = Color.red;
	public string onClickMessage = "";
	public int 	  onClickPoints  = 0;
	public bool   deactivateOnClick = false;
	public int 	  gameTime = 3;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
        rend.material.color = glowColor;
    }
    void OnMouseOver() {
       // rend.material.color -= new Color(0.1F, 0, 0);
    }
    void OnMouseExit() {
        rend.material.color = Color.white;
    }
	void OnMouseDown() {
		if(onClickMessage != "") {
			GameManager.Instance.ShowMessage(onClickMessage);
			onClickMessage = "";
		}
		if(onClickPoints  !=  0) {
			GameManager.Instance.AwardPoints(onClickPoints, transform.position);
			onClickPoints = 0;
			GameManager.Instance.AddGameTime (gameTime);
		}
		if(deactivateOnClick) {
			gameObject.SetActive(false);
		}
	}

}
