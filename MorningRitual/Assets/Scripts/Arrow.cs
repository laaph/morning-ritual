using UnityEngine;
using System.Collections;

	

public class Arrow : MonoBehaviour {
	public GameObject nextRoom;

	void OnMouseDown() {
		Camera.main.GetComponent<CameraMovement>().MoveTo(
			nextRoom.GetComponentInChildren <RoomObjectManager>().cameraPosition,
			delegate() {
				nextRoom.gameObject.SetActive(true);
			});
		gameObject.transform.parent.gameObject.SetActive(false);
	}
}



//Camera.main.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().cameraPosition;