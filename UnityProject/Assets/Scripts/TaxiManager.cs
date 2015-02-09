using UnityEngine;
using System.Collections;

public class TaxiManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static TaxiManager _instance;
	
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
	
	public int passengerCount = 5;
	public int budget;
	
	private float stability;
	private float fuelAmount;

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

	void Start() {
		stability = 1000.0F;
		fuelAmount = 60.0F;
		canvasGameOver = GameObject.FindGameObjectWithTag ("gameOver") as Canvas;
	}

	void Update(){
		if (fuel < 0 || damage < 0) {
			Debug.Log ("GAME OVER");
			canvasGameOver.enabled = true;
			Time.timeScale = 0.0F; 
		} else {
			canvasGameOver.enabled = false;
		}

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

}
