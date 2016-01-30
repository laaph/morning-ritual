using UnityEngine;
using System.Collections;

	

public class Arrow : MonoBehaviour {

	public GameObject nextRoom;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		gameObject.SetActive(false);
		nextRoom.SetActive(true);
		Camera.main.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().cameraPosition;
	}

}
