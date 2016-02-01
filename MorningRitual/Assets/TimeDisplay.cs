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
		this.text.text = string.Format("Time: {0}\n", GameManager.Instance.GameTime);
	}
}
