using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public bool alarmRinging = true;
	public bool inBed = true;
	public float frequency = 0.1f;
	public Vector3 posRange = new Vector3(0.1f, 0.1f, 0f);
	public Vector3 rotRange = new Vector3(0f, 0f, 10f);
	public GameObject snoozeButton;
	public GameObject offButton;

	float timeStart;
	Vector3 startPos;
	Quaternion startRot;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(alarmRinging) {
			if(timeStart+frequency < Time.time) {
				randomToPos();
			}
		}
	}

	void randomToPos() {
		Vector3 toPos = startPos;
		Vector3 toRot = startRot.eulerAngles;
		toPos.x += Random.Range(-1.0f, +1.0f) * posRange.x;
        toPos.y += Random.Range(-1.0f, +1.0f) * posRange.y;

		toRot.z += Random.Range(-1.0f, +1.0f) * rotRange.z;
        transform.position = toPos;
        transform.rotation = Quaternion.Euler(new Vector3(0,0, toRot.z));
        timeStart = Time.time;
	}

	void OnMouseDown() {
		if(alarmRinging) {
			if(inBed) {
				ShowGUI(snoozeButton, transform.position + new Vector3(2.0f, 0.5f, 0f));
				ShowGUI(offButton, transform.position + new Vector3(2.0f, -0.5f, 0f));
			} else {
				ShowGUI(offButton, transform.position + new Vector3(2.0f, 0.5f, 0f));
			}
		}
	}

	void ShowGUI(GameObject button, Vector3 position) {
	//	Vector3 pos = Camera.main.WorldToScreenPoint(position);
	//	button.transform.position = pos;
		button.SetActive(true);
	}

	public void HideGUI() {
		snoozeButton.SetActive(false);
		offButton.SetActive(false);
	}
	public void TurnOffAlarm() {
		GameManager.Instance.AwardPoints(10, this.transform.position);
		HideGUI();
		alarmRinging = false;
		transform.position = startPos;
		transform.rotation = startRot;
	}
	public void SnoozeAlarm() {
		Debug.Log("click snooze");
		//Stub TODO
	}
}
