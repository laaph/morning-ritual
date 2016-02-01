using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static GameManager instanceValue;
	public GameObject initialRoom;
	public MessageBox messageBox;
	public bool pickedUpNewspaper = false;
	public bool tookShower = false;
	public bool hadCoffee = false;

	/// <summary>
	/// Get the global GameManager instance.
	/// </summary>
	public static GameManager Instance {
		get {
			if (!instanceValue) {
				var objs = FindObjectsOfType<GameManager>();
				Debug.Assert(objs.Length == 1);
				instanceValue = objs[0];
			}
			return instanceValue;
		}
	}

	public delegate void Action();
	public event Action ScoreDidChange;
	private int scoreValue;
	public int Score {
		get { return this.scoreValue; }
		private set {
			if (value != this.scoreValue) {
				this.scoreValue = value;
				this.ScoreDidChange.Invoke();
			}
		}
	}

	public delegate void GameTimeAction();
	public event GameTimeAction GameTimeDidChange;
	private int gameTimeValue;
	public int GameTime {
		get { return this.gameTimeValue; }
		private set {
			if (value != this.gameTimeValue) {
				this.gameTimeValue = value;
				this.GameTimeDidChange.Invoke();
			}
		}
	}

	// Use this for initialization
	void Start () {
		this.Score = 0;
		this.GameTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroy() {
		if (this == instanceValue) {
			instanceValue = null;
		}
	}

	public void AwardPoints(int points, Vector3 position) {
		Bubble.DisplayMessage(points.ToString("+#;-#"), position);
		this.Score += points;
	}

	public void AddGameTime(int minutes){
		this.GameTime += minutes;
	}

	public void ShowMessage(string message) {
		messageBox.ShowMessage(message);
	}
}
