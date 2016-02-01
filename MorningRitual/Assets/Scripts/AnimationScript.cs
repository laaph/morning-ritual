using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void EndAnimationEvent() {
		gameObject.SetActive(false);
		GameObject a = GameObject.FindGameObjectWithTag("AlarmClock");
		Clock script = a.GetComponentInChildren<Clock>();
		GameManager.Instance.AddGameTime(0);
		script.alarmRinging = true;
	}
}
