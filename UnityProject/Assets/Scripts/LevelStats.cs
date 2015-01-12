using UnityEngine;
using System.Collections;

public class LevelStats : MonoBehaviour {

	/*
	 * Werte für die Levelbegrenzung (Boundarybox)
	 * */
	public float xMin, xMax, yMin, yMax;

	/*
	 * Eigenschaften für das Space Taxi
	 * */
	public float speedBoost, maxSpeed, fuel, damage, currentXPosition, currentYPosition;

	public int passengerCount, budget;

	public int levelLoadIndex;

	void Start() {

		initPlayerPreferences ();
	}


	/**
	 * Holt aus den PlayerPref alle zwischengespeicherten Werte
	 * */
	void initPlayerPreferences() {
		passengerCount = PlayerPrefs.GetInt ("Passengers");
		damage = PlayerPrefs.GetFloat ("Damage");
		fuel = PlayerPrefs.GetFloat ("Fuel");
		budget = PlayerPrefs.GetInt ("Budget");
		currentXPosition = PlayerPrefs.GetFloat ("PositionX");
		currentYPosition = PlayerPrefs.GetFloat ("PositionY");
	}

	/**
	 * Getter und Setter
	 * */

	public int LevelLoadIndex {
		get {
			return levelLoadIndex;
		}
		
		set {
			levelLoadIndex = value;
		}
	}

	public int PassengerCount {
		get {
			return passengerCount;
		}
		
		set {
			passengerCount = value;
		}
	}

	public int Budget {
		get {
			return budget;
		}
		
		set {
			budget = value;
		}
	}

	public float Damage {
		get {
			return damage;
		}
		
		set {
			damage = value;
		}
	}

	public float Fuel {
		get {
			return fuel;
		}
		
		set {
			fuel = value;
		}
	}

	public float CurrentXPosition {
		get {
			return currentXPosition;
		}
		
		set {
			currentXPosition = value;
		}
	}

	public float CurrentYPosition {
		get {
			return currentYPosition;
		}
		
		set {
			currentYPosition = value;
		}
	}
}
