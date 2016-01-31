using UnityEngine;
using System.Collections;



public class CameraMovement : MonoBehaviour {
	public delegate void Action();

	bool ismoving = false;
	private Vector3 nextCameraPosition;
	private Vector3 cameraStart;
	public float speed = 30.0f;
	public float smoothing = 1.0f;
	private float startTime;
	private float deltaTime;
	private Action callback;

	// Update is called once per frame
	void Update () {
		if (ismoving) {
			float t = (Time.time - startTime) / deltaTime;
			if (t >= 1) {
				ismoving = false;
				Camera.main.transform.position = nextCameraPosition;
				this.callback ();
			} else {
				t = t * (1 - smoothing) + (0.5f - 0.5f * Mathf.Cos(t * Mathf.PI)) * smoothing;
				Camera.main.transform.position = Vector3.Lerp (cameraStart, nextCameraPosition, t);
			}
		}
	}

	public void MoveTo(Vector3 target, Action callback) {
		ismoving = true;
		nextCameraPosition = target;
		cameraStart = Camera.main.transform.position;
		float dist = Vector3.Distance(cameraStart, nextCameraPosition);
		startTime = Time.time;
		deltaTime = dist / speed;
		this.callback = callback;
	}
}
