﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*
	 * Das sind die allgemeinen Eigenschaften fürs Taxi.
	 * */
	private float speedBoost;

	private float maxSpeed;

	private float damage;

	private float fuel;

	private int budget;

	private int passengerCount;
	
	public static int passengerMaxCount = 5;

	public static float fuelAmount = 100;
	
	private GameController gameController;

	// die Position müssen berücksichtigt werden, wenn das Taxi in die Map zurückkehrt.
	private static float currentXPosition;
	
	private static float currentYPosition;
	
	// hier müssen die Eigenschaften, abhängig vom Level geändert werden.
	private float angularDrag;
	
	private float gravityScale;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	private static bool isEnteringMap;

	// Use this for initialization
	void Start () {

		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) {

			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		// Standardwerte für das Taxi zur Steuerung
		speedBoost = levelStats.speedBoost;
		maxSpeed = levelStats.maxSpeed;

		// Initialisierung der Werte für Passagiere, Fuel und Damage
		initPlayerValues ();

	}
	
	void FixedUpdate() {

		// Taxi Steuerung einbinden.
		taxiControl ();

		//Die Levelbegrenzung festlegen
		setBoundary ();

	}

	void OnDestroy() {
		currentXPosition = rigidbody2D.position.x;
		currentYPosition = rigidbody2D.position.y;

		Debug.Log ("Position x: " + currentXPosition);
	}
	
	/*
	 * Werte werden von den PlayerPrefs abgefragt. Sonst die Default Werte.
	 * */
	void initPlayerValues() {
		passengerCount = levelStats.PassengerCount;
		damage = levelStats.Damage;
		fuel = levelStats.Fuel;
		budget = levelStats.Budget;

		// letzte bekannte Position des Taxis laden
		//transform.position = new Vector2 (currentXPosition, currentYPosition);

		// Falls fuel den Wert 0 hat. Wurde das Spiel gestartet und wir fuel wird auf Default gesetzt;
		fuel = (fuel == 0) ? fuelAmount : fuel;
	}

	/*
	 * Setzt die Levelbegrenzung
	 * */
	void setBoundary() {
		rigidbody2D.position = new Vector2
			(
				Mathf.Clamp (rigidbody2D.position.x, levelStats.xMin, levelStats.xMax),
				Mathf.Clamp (rigidbody2D.position.y, levelStats.yMin, levelStats.yMax)
				
			);
	}

	/**
	 * Steuerung des Taxis über physikalische Kräfte.
	 * */
	void taxiControl() {

		if (levelStats.ExitLevelHeight == -1 | rigidbody2D.position.y < levelStats.ExitLevelHeight) {
				
			//Die Standard Steuerung
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			//Steuerung rechts
			if (horizontal > 0) {
				rigidbody2D.AddForce (new Vector2 (speedBoost, 0));
				//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
				rigidbody2D.angularVelocity = 0;
			}

			//Steuerung links
			if (horizontal < 0) {
				rigidbody2D.AddForce (new Vector2 (-speedBoost, 0));
				//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
				rigidbody2D.angularVelocity = 0;
			}

			//Steuerung oben
			if (vertical > 0) {
				rigidbody2D.AddForce (new Vector2 (0, speedBoost));
				//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
				rigidbody2D.angularVelocity = 0;
			}

			//Steuerung unten
			if (vertical < 0) {
				rigidbody2D.AddForce (new Vector2 (0, -speedBoost));
				//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
				rigidbody2D.angularVelocity = 0;
			}
		} else {
			Application.LoadLevel(0);
		}
		
		////	MAXIMALE GESCHWINDIGKEIT    ////
		
		if (rigidbody2D.velocity.magnitude > maxSpeed) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
		}
	}

	/*
	 * Es wird geprüft, ob der Spieler sich auf der Map befindet.
	 * */
	bool isPlayerInMap() {
		return Application.loadedLevel == 0;
	}
}
