using UnityEngine;
using System.Collections;

public class RoomObjectManager : MonoBehaviour {

	public Vector3 cameraPosition;
	public bool isInitialRoom = false;

	// Use this for initialization
	void Start () {
		if(isInitialRoom) {
			Camera.main.transform.position = cameraPosition;
			gameObject.SetActive(true);
		} else {
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
