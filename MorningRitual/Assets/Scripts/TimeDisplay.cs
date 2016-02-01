using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeDisplay : MonoBehaviour {
	private Text text;

	// Use this for initialization
	void Start () {
		this.text = GetComponent<Text>();
		GameManager.Instance.GameTimeDidChange += this.OnTimeChanged;
		this.OnTimeChanged();
	}

	void OnTimeChanged() {
		int minutes = GameManager.Instance.GameTime;
		if (minutes > 9) {
			this.text.text = string.Format ("Time: 7:{0}", GameManager.Instance.GameTime);
		} else {
			this.text.text = string.Format ("Time: 7:0{0}", GameManager.Instance.GameTime);
		}
	}
}
