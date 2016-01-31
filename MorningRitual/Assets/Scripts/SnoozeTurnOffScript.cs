using UnityEngine;
using System.Collections;

public class SnoozeTurnOffScript : MonoBehaviour {
	public bool snooze;
	public bool turnOff;
	GameObject clock;
	Clock script;
	// Use this for initialization
	void Start () {
		clock = GameObject.FindGameObjectWithTag("AlarmClock");
		script = clock.GetComponentInChildren<Clock>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		if(snooze) {
			script.SnoozeAlarm();
		}
		if(turnOff) {
			script.TurnOffAlarm();
		}
	}
}
