using UnityEngine;
using System.Collections;

public class UserObjectCommonFunctions : MonoBehaviour {
	Renderer rend;
	public Color glowColor = Color.red;

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
//	void OnMouseDown() {
//		GameManager.Instance.AwardPoints(50, this.transform.position);
//		GameManager.Instance.ShowMessage("Oh, what a wonderful day!");
//	}

}
