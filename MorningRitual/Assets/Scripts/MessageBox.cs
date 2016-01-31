using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : MonoBehaviour {
	private Vector3 showPosition, hidePosition;
	private float startTime = float.NegativeInfinity;
	public float moveTime = 0.25f;
	public float displayTime = 2.0f;
	public float distance = 200.0f;
	private Text text;

	// Use this for initialization
	void Start () {
		this.showPosition = this.transform.position;
		this.hidePosition = this.showPosition - new Vector3(0, this.distance, 0);
		this.transform.position = this.hidePosition;
		this.text = this.GetComponentInChildren<Text>();
	}
	
	void Update () {
		float relTime = Time.time - this.startTime;
		if (relTime <= 0 || relTime >= this.displayTime) {
			this.transform.position = this.hidePosition;
		} else {
			float t = relTime / this.moveTime;
			if (t >= 1) {
				this.transform.position = this.showPosition;
			} else {
				this.transform.position = Vector3.Lerp(this.hidePosition, this.showPosition, t);
			}
		}
	}

	public void ShowMessage(string message) {
		this.startTime = Time.time;
		this.text.text = message;
	}
}
