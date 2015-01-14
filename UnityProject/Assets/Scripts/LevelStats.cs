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
	public float exitLevelHeight;

	private string activeOrbName;



	void Start() {

		initPlayerPreferences ();
	}

	void OnApplicationQuit() {
		// Falls das Spiel beendet wird, müssen (vorerst) alle PlayerPrefs gelöscht werden, sonst
		// werden weitere Planeten aktiviert.
		PlayerPrefs.DeleteAll ();
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
	 * Getter und Setter für die Planetenaktivierung und Level Index Verwaltung.
	 * Wird alles in den Player Prefs verwaltet und über die GameObject Namen zugänglich gemacht.
	 * */
	public string activeOrbInPrefs(string name) {
		return PlayerPrefs.GetString (name);
	}

	public void setLevelIndexInPrefs(string name, int level) {
		PlayerPrefs.SetInt (name, level);
	}

	public int getLevelIndexInPrefs(string name) {
		return PlayerPrefs.GetInt (name);
	}

	/**
	 * Getter und Setter
	 * */
	

	public string ActiveOrbName {
		get {
			return activeOrbName;
		}
		
		set {
			activeOrbName = value;
			PlayerPrefs.SetString(activeOrbName, activeOrbName);
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

	public float ExitLevelHeight {
		get {
			return exitLevelHeight;
		}
		
		set {
			exitLevelHeight = value;
		}
	}

}
