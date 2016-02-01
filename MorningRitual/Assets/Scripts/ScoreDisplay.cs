using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {
	private Text text;

	// Use this for initialization
	void Start () {
		this.text = GetComponent<Text>();
		GameManager.Instance.ScoreDidChange += this.OnScoreChanged;
		this.OnScoreChanged();
	}
	
	void OnScoreChanged() {
		this.text.text = string.Format("Score: {0}\n", GameManager.Instance.Score);
	}
}
