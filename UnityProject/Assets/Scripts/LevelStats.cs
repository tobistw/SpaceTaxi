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
	private float fuel, damage;

	public float speedBoost, maxSpeed;

	private int aGameIsRunning, highscore;

	private float stability;
	private float fuelVolume;

	/*
	 * Leveleigenschaften
	 * */
	public float exitLevelHeight;

	private string activeOrbName;

	private static Vector2 currentTaxiPosition;

	public bool isMothershipActive;


	private int newGameStart;
	private int newGameStartPlayer;
	private int newGameStartOrb;



	void Start() {
		stability = 1000.0F;
		fuelVolume = 60.0F;
		initPlayerPreferences ();
	}


	void Update(){
		/*if (Input.GetKeyDown (KeyCode.A)) {
			PlayerPrefs.SetInt ("Budget", 100);

		}*/
	
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
		/*passengerCount = PlayerPrefs.GetInt ("Passengers");
		damage = PlayerPrefs.GetFloat ("Damage");
		fuel = PlayerPrefs.GetFloat ("Fuel");
		budget = PlayerPrefs.GetInt ("Budget");
		achievement = PlayerPrefs.GetInt ("Achievement");


		if (damage == 0) {
			PlayerPrefs.SetFloat("Damage", stability);		
		}
		if (fuel == 0) {
			PlayerPrefs.SetFloat("Fuel", fuelVolume);	
		}
		//nur für aktuellen test
		if (achievement == 0) {
			PlayerPrefs.SetInt("Achievement", 140);	
		}*/
		aGameIsRunning = PlayerPrefs.GetInt ("GameIsRunning");
		if(aGameIsRunning == null){
			PlayerPrefs.SetInt("GameIsRunning", 0);
		}





	}
	

	/**
	 * Getter und Setter für die  Level Index Verwaltung.
	 * Wird alles in den Player Prefs verwaltet und über die GameObject Namen zugänglich gemacht.
	 * */

	/*public void setLevelIndexInPrefs(string name, int level) {
		PlayerPrefs.SetInt (name, level);
	}

	public int getLevelIndexInPrefs(string name) {
		return PlayerPrefs.GetInt (name);
	}

	public void setPassengersOnOrb(string levelIndexString, int passengers) {
		PlayerPrefs.SetInt (levelIndexString, passengers);
	}

	public int getPassengersOnOrb(string levelIndexString) {
		return PlayerPrefs.GetInt (levelIndexString);
	}*/

	/**
	 * Getter und Setter
	 * */
	



	/*public string ActiveOrbName {
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
			passengerCount = PlayerPrefs.GetInt ("Passengers");
			return passengerCount;
		}
		
		set {
			passengerCount = value;
			PlayerPrefs.SetInt ("Passengers", passengerCount);
		}
	}

	public int Budget {
		get {
			budget = PlayerPrefs.GetInt ("Budget");
			return budget;
		}
		
		set {
			budget = value;
			PlayerPrefs.SetInt ("Budget", budget);
		}
	}

	public float Damage {
		get {
			damage = PlayerPrefs.GetFloat ("Damage");
			return damage;
		}
		
		set {
			damage = value;
			PlayerPrefs.SetFloat ("Damage", damage);
		}
	}

	public float Fuel {
		get {
			fuel = PlayerPrefs.GetFloat ("Fuel");
			return fuel;
		}
		
		set {
			fuel = value;
			PlayerPrefs.SetFloat ("Fuel", fuel);
		}
	}

	public int Achievement{
		get {
			achievement = PlayerPrefs.GetInt ("Achievement");
			return achievement;
		}
		set {
			achievement = value;
			PlayerPrefs.SetInt("Achievement", achievement);
		}
	}
*/
	public float ExitLevelHeight {
		get {
			return exitLevelHeight;
		}
		
		set {
			exitLevelHeight = value;
		}
	}

	public int Highscore {
		get {
			return PlayerPrefs.GetInt ("Highscore");
		}
		
		set {
			PlayerPrefs.SetInt("Highscore", value);
		}
	}


	/*
	public Vector2 CurrentPosition {
		get {
			return currentTaxiPosition;
		}
		
		set {
			currentTaxiPosition = value;
		}
	}

	*/
	public bool IsMothershipActive {
		get {
			return isMothershipActive;
		}
		
		set {
			isMothershipActive = value;
		}
	}






	/*
	public float Stability {
		get {
			return stability;
		}
		
		set {
			stability = value;
		}
	}

	public float FuelVolume {
		get {
			return fuelVolume;
		}
		
		set {
			fuelVolume = value;
		}
	}
*/



	public bool GameIsRunning {
		get {

			aGameIsRunning = PlayerPrefs.GetInt ("GameIsRunning");

			return (aGameIsRunning == 1);
		}
		set {

			if(value){
				aGameIsRunning = 1;
			} else {
				aGameIsRunning = 0;
			}
			PlayerPrefs.SetInt("GameIsRunning", aGameIsRunning);
		}
		//Debug.Log("läuft ein Spiel?: " +  levelStats.GameIsRunning);
	}

}
