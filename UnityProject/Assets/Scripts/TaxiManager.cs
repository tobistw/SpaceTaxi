using UnityEngine;
using System.Collections;

public class TaxiManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static TaxiManager _instance;

	private  LevelStats levelStats;

	//This is the public reference that other classes will use
	public static TaxiManager instance {
		get {

			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<TaxiManager>();
				//Tell unity not to destroy this object when loading a new scene!

				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	/*
	 * Eigenschaften für das Space Taxi
	 * */
	public float fuel, damage;

	private Canvas canvasGameOver;

	public int achievement;
	
	public float speedBoost, maxSpeed, gravity;

	public int highscore;
	public bool newHighscore;
	public bool isGameOver;

	public int passengerCount = 5;
	public int budget = 100;
	private bool isNewLevelReached;
	
	private float stability;
	private float fuelAmount;

	private GameController gameController;


	public float defaultStability = 1000.0F;
	public float defaultFuel = 60.0F;

	private Vector2 currentTaxiPosition;




	void Awake() {
	

		if (_instance == null) {
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
		
	}


	/*void Awake() {
		////////
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {				
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}
		
		if(levelStats.NewGameStarted){
		///////// 
			if (_instance == null) {
				//If I am the first instance, make me the Singleton
				_instance = this;
				DontDestroyOnLoad(this);
			} else {
				//If a Singleton already exists and you find
				//another reference in scene, destroy it!
				if(this != _instance)
					Destroy(this.gameObject);
			}
		/////
			levelStats.NewGameStarted = false;
		}
		///////
		
	}*/

	void Start() {
		stability = defaultStability;
		fuelAmount = defaultFuel;
		currentTaxiPosition = new Vector2 (236.2F, 88.0F);
		isNewLevelReached = false;
	}

	/*public void Reset(){


		isGameOver = false;
		stability = defaultStability;
		fuelAmount = defaultFuel;
		currentTaxiPosition = new Vector2 (236.2F, 88.0F);
		isNewLevelReached = false;
		budget = 100;
		nextLevelBudget = 150;
	}*/

	void Update(){




		if (fuel < 0 || damage < 0) {
			//Debug.Log ("GAME OVER");
			//StartCoroutine(setGameOver());
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			if (gameControllerObject != null) {				
				levelStats = gameControllerObject.GetComponent<LevelStats> ();
			} else {
				Debug.Log("Cant find Game Controller Object");
			}

			fuel = 0.1F;
			damage = 1;
			GameObject gameObjectGameOver = GameObject.FindGameObjectWithTag ("gameOver");
			canvasGameOver = gameObjectGameOver.GetComponent<Canvas> ();
			canvasGameOver.enabled = true;
			Time.timeScale = 0.0F;
			//Highscore ausrechnen
			isGameOver = true;
			levelStats.GameIsRunning = false;


		} 

		if (budget >= achievement && !isNewLevelReached) {
			achievement += achievement;
			// Aufruf für nächstes Level.
			isNewLevelReached = true;
		}
	}

	/*void setHighscore(){
		newHighscore = false;
		if (levelStats.Highscore == null || levelStats.Highscore < budget) {
			levelStats.Highscore = budget;
			newHighscore = true;
		}
		highscore = levelStats.Highscore;
	}*/


	IEnumerator setGameOver() {
		yield return new WaitForSeconds (1f);
		fuel = 0.1F;
		damage = 1;
		GameObject gameObjectGameOver = GameObject.FindGameObjectWithTag ("gameOver");
		canvasGameOver = gameObjectGameOver.GetComponent<Canvas> ();
		canvasGameOver.enabled = true;
		Time.timeScale = 0.0F; 
	}

	public float Fuel {
		get {
			return this.fuel;
		}
		set {
			fuel = value;
		}
	}

	public float Damage {
		get {
			return this.damage;
		}
		set {
			damage = value;
		}
	}

	public int Budget {
		get {
			return this.budget;
		}
		set {
			budget = value;
		}
	}

	public int PassengerCount {
		get {
			return this.passengerCount;
		}
		set {
			passengerCount = value;
		}
	}

	public float Stability {
		get {
			return this.stability;
		}
		set {
			stability = value;
		}
	}

	public float FuelAmount {
		get {
			return this.fuelAmount;
		}
		set {
			fuelAmount = value;
		}
	}

	public int Achievement {
		get {
			return this.achievement;
		}
		set {
			achievement = value;
		}
	}

	public Vector2 CurrentTaxiPosition {
		get {
			return this.currentTaxiPosition;
		}
		set {
			currentTaxiPosition = value;
		}
	} 

	public bool IsNewLevelReached {
		get {
			return this.isNewLevelReached;
		}
		set {
			isNewLevelReached = value;
		}
	}
}
