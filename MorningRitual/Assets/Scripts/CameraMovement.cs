using UnityEngine;
using System.Collections;



public class CameraMovement : MonoBehaviour {
	public delegate void Action();

	bool ismoving = false;
	private Vector3 nextCameraPosition;
	private Vector3 cameraStart;
	//	public ref CamVelocity = 10.0;
	public float smoothTime = 0.3F;
	private float startTime;
	private Action callback;

	// Update is called once per frame
	void Update () {
		if (ismoving) {
			float t = (Time.time - startTime) / smoothTime;
			if (t >= 1) {
				ismoving = false;
				Camera.main.transform.position = nextCameraPosition;
				this.callback ();
			} else {
				Camera.main.transform.position = Vector3.Lerp (cameraStart, nextCameraPosition, t);
			}
		}
	}

	public void MoveTo(Vector3 target, Action callback) {
		ismoving = true;
		nextCameraPosition = target;
		cameraStart = Camera.main.transform.position;
		startTime = Time.time;
		this.callback = callback;
	}
}
