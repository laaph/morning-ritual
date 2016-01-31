using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public bool alarmRinging = true;
	public float frequency = 0.1f;
	public Vector3 posRange = new Vector3(0.1f, 0.1f, 0f);
	public Vector3 rotRange = new Vector3(0f, 0f, 10f);

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
}
