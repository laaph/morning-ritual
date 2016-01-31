using UnityEngine;
using System.Collections;

	

public class Arrow : MonoBehaviour {
	public GameObject nextRoom;

	void OnMouseDown() {

		Camera.main.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().cameraPosition;
		nextRoom.gameObject.SetActive(true);
		gameObject.transform.parent.gameObject.SetActive(false);
	}
}



//Camera.main.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().cameraPosition;