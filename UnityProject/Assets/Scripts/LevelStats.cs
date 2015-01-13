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
	public float speedBoost, maxSpeed, fuel, damage;

	public int passengerCount, budget;

	/*
	 * Leveleigenschaften
	 * */
	public int levelLoadIndex;

	public GameObject[] atmosphereObjects;

	public int activeOrbArraySize;

	public Hashtable activeOrbTable;


	void Awake () {
		activeOrbTable = new Hashtable ();
	}

	void Start() {

		initPlayerPreferences ();
		initActiveOrbTable ();
	}


	/**
	 * Holt aus den PlayerPref alle zwischengespeicherten Werte
	 * */
	void initPlayerPreferences() {
		passengerCount = PlayerPrefs.GetInt ("Passengers");
		damage = PlayerPrefs.GetFloat ("Damage");
		fuel = PlayerPrefs.GetFloat ("Fuel");
		budget = PlayerPrefs.GetInt ("Budget");
	}

	/**
	 * Erezugt eine Schlüssel Werte Tabelle mit den aktiven Planeten
	 * */
	void initActiveOrbTable() {

		for (int i = 0; i < atmosphereObjects.Length; i++) {
				int booleanNumber = PlayerPrefs.GetInt ("Orb" + i.ToString ());
				activeOrbTable.Add (0, booleanNumber);
		}
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
	
}
