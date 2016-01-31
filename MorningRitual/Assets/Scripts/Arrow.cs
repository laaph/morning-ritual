using UnityEngine;
using System.Collections;

	

public class Arrow : MonoBehaviour {
	public GameObject nextRoom;
	public string addText;

	void OnMouseDown() {
		Camera.main.GetComponent<CameraMovement>().MoveTo(
			nextRoom.GetComponentInChildren <RoomObjectManager>().cameraPosition,
			delegate() {
				nextRoom.gameObject.SetActive(true);
			});
		gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
		gameObject.transform.parent.gameObject.SetActive(false);

		if(addText != "") {
			GameManager.Instance.ShowMessage(addText);
			addText = "";
		}
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player != null) { // Can be null when player is not active
			player.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().galePosition;
			player.SetActive(true);
		}
	}
}



//Camera.main.transform.position = nextRoom.GetComponentInChildren<RoomObjectManager>().cameraPosition;