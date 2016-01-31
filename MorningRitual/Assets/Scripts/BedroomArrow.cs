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
		GameObject c = GameObject.FindGameObjectWithTag("AlarmClock");
		Clock s = c.GetComponentInChildren<Clock>();
		if(s.alarmRinging){
			GameManager.Instance.ShowMessage("That alarm needs to stop now...");
		} else {
			GameManager.Instance.ShowMessage("I can't believe I managed to get out of bed with the alarm off");
		}
		s.inBed = false;
		s.HideGUI();
	}
}
