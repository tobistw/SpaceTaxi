using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*
	 * Das sind die allgemeinen Eigenschaften fürs Taxi.
	 * */
	private float speedBoost;

	private float maxSpeed;

	private float damage;

	private int passengerCount;
	
	public static int passengerMaxCount = 5;

	public static float mapSpeedBoost = 30.0F;

	public static float mapMaxSpeed = 40.0F;

	public static float levelSpeedBoost = 20.0F;
	
	public static float levelMaxSpeed = 24.0F;
	
	private GameController gameController;

	// die Position müssen berücksichtigt werden, wenn das Taxi in die Map zurückkehrt.
	private float currentXPosition;
	
	private float currentYPosition;
	
	// hier müssen die Eigenschaften, abhängig vom Level geändert werden.
	private float angularDrag;
	
	private float gravityScale;

	// es werden die Levelbegrenzungen verwaltet.
	private Boundary boundary;
	

	// Use this for initialization
	void Start () {

		// Initalisierung der Boundary im Level
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) {

			boundary = gameControllerObject.GetComponent<Boundary> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		// Standardwerte für die Map
		if (isPlayerInMap ()) {
			speedBoost = mapSpeedBoost;
			maxSpeed = mapMaxSpeed;
		} else {
			// Standardwerte für Level
			speedBoost = levelSpeedBoost;
			maxSpeed = levelMaxSpeed;
		}
	}
	
	void FixedUpdate() {

		//Die Standard Steuerung

		//Steuerung nach links
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody2D.AddForce (new Vector2 (-speedBoost, 0));
			//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
			rigidbody2D.angularVelocity = 0;
		} 
		//Steuerung nach rechts
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidbody2D.AddForce (new Vector2 (speedBoost, 0));
			//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
			rigidbody2D.angularVelocity = 0;
		}
		//Steuerung nach oben
		if (Input.GetKey (KeyCode.UpArrow)) {
			rigidbody2D.AddForce (new Vector2 (0, speedBoost));
			//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
			rigidbody2D.angularVelocity = 0;
		}
		//Steuerung nach unten
		if (Input.GetKey (KeyCode.DownArrow)) {
			rigidbody2D.AddForce (new Vector2 (0, -speedBoost));
			//Die Geschwindigkeit mit der sich das Taxi, im Falle einer Drehung, dreht
			rigidbody2D.angularVelocity = 0;
		} 

		////	MAXIMALE GESCHWINDIGKEIT    ////
		
		if (rigidbody2D.velocity.magnitude > maxSpeed) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
		}

		//Die Levelbegrenzung festlegen

		rigidbody2D.position = new Vector2
		(
				Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax)
			    
		);
	}
	
	/*
	 * Werte werden von den PlayerPrefs abgefragt. Sonst die Default Werte.
	 * */
	void initPlayerValues() {
		speedBoost = PlayerPrefs.GetFloat ("SpeedBoost");
		maxSpeed = PlayerPrefs.GetFloat ("MaxSpeed");

	}

	/*
	 * Es wird geprüft, ob der Spieler sich auf der Map befindet.
	 * */
	bool isPlayerInMap() {
		return Application.loadedLevel == 0;
	}
}
