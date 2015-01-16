using UnityEngine;
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
	private Vector2 currentPosition;

	
	// hier müssen die Eigenschaften, abhängig vom Level geändert werden.
	private float angularDrag;
	
	private float gravityScale;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// fuer die Prüfung, ob sich der Spieler in der Map befindet
	private static bool isPlayerInMap;

	// Use this for initialization
	void Start () {

		// Abfrage wo sich der Spieler befindet.
		isPlayerInMap = (Application.loadedLevel == 0) ? true : false;

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
	

	/*
	 * Werte werden von den PlayerPrefs abgefragt. Sonst die Default Werte.
	 * */
	void initPlayerValues() {
		passengerCount = levelStats.PassengerCount;
		damage = levelStats.Damage;
		fuel = levelStats.Fuel;
		budget = levelStats.Budget;

		// letzte bekannte Position des Taxis laden
		if (isPlayerInMap) {

			setPlayerPosition();
		}

		// Falls fuel den Wert 0 hat, wurde das Spiel gestartet und fuel wird auf Default gesetzt.
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

		// Falls der Spieler in einem Level ist, wird geprüft ab welcher Höhe dieser in die Map
		// zurückkehrt. Bei dem Wert -1 handelt es sich um die Map.
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
			// Zurück in die Map.
			Application.LoadLevel(0);
		}
		
		////	MAXIMALE GESCHWINDIGKEIT    ////
		
		if (rigidbody2D.velocity.magnitude > maxSpeed) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
		}
	}
	
	/*
	 * Die Spielerposition bei Eintritt in die Map wird gesetzt.
	 * */
	void setPlayerPosition() {

		currentPosition = levelStats.CurrentPosition;
		if (currentPosition.x == 0 && currentPosition.y == 0) {
			rigidbody2D.position = new Vector2 (186.0F, 112.0F);		
		} else {
			rigidbody2D.position = currentPosition;
		}
	}
}
