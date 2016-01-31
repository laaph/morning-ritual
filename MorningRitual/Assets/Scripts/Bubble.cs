using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bubble : MonoBehaviour {
	public float lifetime = 2.0f;
	public float distance = 50.0f;

	private static Bubble instance;

	private Text text;
	private Vector3 position;
	private float startTime;

	void Awake() {
		if (!instance) {
			gameObject.SetActive(false);
			instance = this;
		}
		this.text = GetComponent<Text>();
	}

	void OnDestroy() {
		if (this == instance) {
			instance = null;
		}
	}

	public static void DisplayMessage(string message, Vector3 position) {
		Debug.Assert(instance != null);
		Bubble obj = Instantiate(instance);
		obj.gameObject.SetActive(true);
		obj.text.text = message;
		obj.transform.SetParent(instance.transform.parent);
		obj.position = position;
		obj.startTime = Time.time;
	}

	void LateUpdate() {
		float t = (Time.time - this.startTime) / this.lifetime;
		if (t > 1.0f) {
			Destroy(gameObject);
			return;
		}
		Vector3 pos = Camera.main.WorldToScreenPoint(this.position);
		pos += new Vector3(0.0f, (t - 0.5f) * this.distance, 0.0f);
		this.transform.position = pos;
	}
}
