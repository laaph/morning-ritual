﻿using UnityEngine;
using System.Collections;

public class Mug : MonoBehaviour {
	private enum State {
		Empty,
		TooHot,
		JustRight,
		TooCold,
	}
	public GameObject steamTooHot, steamJustRight;
	private State state = State.Empty;
	private float coffeeTime;
	public float cooldownTime1 = 4.0f;
	public float cooldownTime2 = 4.0f;

	// Use this for initialization
	void Start () {
		if (!this.steamJustRight) {
			Debug.LogError("Mug missing just right steam");
		}
		if (!this.steamTooHot) {
			Debug.LogError("Mug is missing hot steam");
		}
		this.UpdateSteam();
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
		switch (this.state) {
			case State.Empty:
				GameManager.Instance.ShowMessage("This cup is empty, like my life.");
				break;
			case State.TooHot:
				GameManager.Instance.ShowMessage("Ouch, that coffee is HOT!");
				break;
			case State.JustRight:
				GameManager.Instance.ShowMessage("Nice, that sure was coffee!");
				break;
			case State.TooCold:
				GameManager.Instance.ShowMessage("That coffee is cold and heartless, like my ex!");
				break;
		}
		this.state = State.Empty;
		this.UpdateSteam();
	}

	public void AddCoffee() {
		if (this.state == State.Empty) {
			GameManager.Instance.ShowMessage("I’ll just pour myself a cup of joe.");
			this.coffeeTime = Time.time;
			this.state = State.TooHot;
			this.UpdateSteam();
		} else {
			GameManager.Instance.ShowMessage("I already have coffee.");
			// Spill the coffee
		}
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
