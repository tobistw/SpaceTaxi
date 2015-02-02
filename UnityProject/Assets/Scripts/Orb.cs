﻿using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	public static GameObject atmosphereObject;
	
	private CircleCollider2D atmosphereCollider;

	private Atmosphere atmoScript;
	
	public static Atmosphere[] atmospheres;

	// Jeder Planet weiß, ob er aktiv ist.
	public bool isActive;

	// Jeder Planet hat unterschiedlich viele Passagiere.
	public int passengers;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// Der Orb Manager
	public OrbManager orbManager;


	// Use this for initialization
	void Start () {

		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		renderAtmosphere ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* Die Atmosphäre wird gerendert, sobald der Planet auf aktiv gesetzt wurde.
	 * 
	 * */
	void renderAtmosphere() {

		// Der aktive Planet wird über die LevelStats ermittelt. Das wird dafür benötigt, 
		// wenn das Map Level erneut geladen wird.
		if (OrbManager.instance.isInActiveOrbs(this.name)){
			isActive = true;
		}

		// hier wird gerendert.
		if (isActive) {

			// Hier wird der aktive Planetenname im OrbManager gespeichert.
			OrbManager.instance.addActiveOrb(this.name);

			atmosphereObject = transform.GetChild(0).gameObject;
			atmosphereCollider = atmosphereObject.GetComponent<CircleCollider2D>();

			atmosphereObject.renderer.enabled = true;
			atmosphereCollider.enabled = true;
			atmosphereCollider.isTrigger = true;

			createPassengerPopulation();
		}
	}

	/**
	 * Jeder aktive Planet erzeugt die Anzahl der Passagiere. Die Anzahl hängt vom Level ab und nimmt
	 * bei höheren Level entsprechend zu.
	 */
	void createPassengerPopulation() {
		atmoScript = atmosphereObject.GetComponent<Atmosphere>();

		if (atmoScript != null) {
		
			int levelIndex = atmoScript.LevelIndex;
			switch(levelIndex) {
			case 1:
				passengers = randomPassengerGenerator(1, levelIndex + 1);
				break;
				
			case 2:
				passengers = randomPassengerGenerator(1, levelIndex + 1);
				break;
				
			case 3:
				passengers = randomPassengerGenerator(1, levelIndex + 1);
				break;
				
			case 4:
				passengers = randomPassengerGenerator(1, levelIndex + 1);
				break;
			}

			// Die Passagieranzahl wird in den gesetzt und über den Level Index referenziert.
			Debug.Log("Planet: " + atmoScript.name + " Anzahl Passagiere: " + passengers);

			OrbManager.instance.setPassengersOnOrb(levelIndex, passengers);
		}
	}
	/**
	 * Generator um zufällig die Anzahl der Passagiere auf den Planeten zu erzeugen. 
	 */
	private int randomPassengerGenerator(int min, int max) {
		return Random.Range (min, max);
	}

	// Getter und Setter

	public bool IsActive {

		get {
			return isActive;
		}

		set {
			isActive = value;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.relativeVelocity.magnitude > 5) {
			TaxiManager.instance.Damage = TaxiManager.instance.Damage - collision.relativeVelocity.magnitude;
		}

		//Debug.Log (PlayerPrefs.GetFloat ("Damage"));
		//Debug.Log (collision.relativeVelocity.magnitude);
		//if (collision.relativeVelocity.magnitude > 2)
		//	audio.Play();
		
	}
	
}
