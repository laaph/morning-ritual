using UnityEngine;
using System.Collections;

public class BedroomArrow : MonoBehaviour {
	public GameObject galeSleeping;
	public GameObject galeStanding;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		galeSleeping.SetActive(false);
		galeStanding.SetActive(true);
	}
}
