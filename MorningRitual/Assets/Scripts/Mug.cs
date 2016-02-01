using UnityEngine;
using System.Collections;

public class Mug : MonoBehaviour {

	bool awardedPoints = false;
	private enum State {
		Empty,
		TooHot,
		JustRight,
		TooCold,
	}
	public GameObject steamTooHot, steamJustRight;
	public GameObject spill;
	private State state = State.Empty;
	private float coffeeTime;
	public float cooldownTime1 = 4.0f;
	public float cooldownTime2 = 4.0f;
	public AudioClip audioPour, audioSpill, audioHot, audioYuck, audioYum;
	public int gameTime = 3;

	// Use this for initialization
	void Start () {
		if (!this.steamJustRight) {
			Debug.LogError("Mug missing just right steam");
		}
		if (!this.steamTooHot) {
			Debug.LogError("Mug is missing hot steam");
		}
		if (!this.spill) {
			Debug.LogError("Mug is missing spill");
		} else {
			this.spill.SetActive(false);
		}
		this.UpdateSteam();
		GameManager.Instance.AddGameTime (gameTime);
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time - this.coffeeTime;
		switch (this.state) {
			case State.TooHot:
				if (time >= this.cooldownTime1) {
					this.state = State.JustRight;
					this.UpdateSteam();
				}
				break;
			case State.JustRight:
				if (time >= this.cooldownTime1 + this.cooldownTime2) {
					this.state = State.TooCold;
					this.UpdateSteam();
				}
				break;
		}
	}

	void OnMouseDown() {
		AudioClip clip = null;
		int points = 0;
		switch (this.state) {
			case State.Empty:
				GameManager.Instance.ShowMessage("This cup is empty, like my life.");
				break;
			case State.TooHot:
				GameManager.Instance.ShowMessage("Ouch, that coffee is HOT!");
				GameManager.Instance.hadCoffee = true;
				clip = this.audioHot;
				GameManager.Instance.AwardPoints(-50, transform.position);
				break;
			case State.JustRight:
				GameManager.Instance.ShowMessage("Nice, that sure was coffee!");
				GameManager.Instance.hadCoffee = true;
				if(!awardedPoints) {
					GameManager.Instance.AwardPoints(50, transform.position);
					awardedPoints = true;
				}
				break;
			case State.TooCold:
				GameManager.Instance.ShowMessage("That coffee is cold and heartless, like my ex!");
				GameManager.Instance.hadCoffee = true;
				clip = this.audioYuck;
				GameManager.Instance.AwardPoints(-25, transform.position);
				break;
		}
		if (points != 0) {
			GameManager.Instance.AwardPoints(points, this.transform.position);
		}
		if (clip) {
			var source = this.GetComponent<AudioSource>();
			source.clip = clip;
			source.Play();
		}
		this.state = State.Empty;
		this.UpdateSteam();
	}

	public void AddCoffee() {
		AudioClip clip;
		if (this.state == State.Empty) {
			GameManager.Instance.ShowMessage("I’ll just pour myself a cup of joe.");
			this.coffeeTime = Time.time;
			this.state = State.TooHot;
			this.UpdateSteam();
			clip = this.audioPour;
		} else {
			GameManager.Instance.ShowMessage("Shit, the mug was already full.");
			if (this.spill) {
				this.spill.SetActive(true);
			}
			GameManager.Instance.AwardPoints(-50, this.transform.position);
			clip = this.audioSpill;
		}
		var source = this.GetComponent<AudioSource>();
		source.clip = clip;
		source.Play();
	}

	private void UpdateSteam() {
		if (this.steamTooHot) {
			this.steamTooHot.SetActive(this.state == State.TooHot);
		}
		if (this.steamJustRight) {
			this.steamJustRight.SetActive(this.state == State.JustRight || this.state == State.TooHot);
		}
	}
}
