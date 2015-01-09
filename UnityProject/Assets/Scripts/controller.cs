using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	//noetig für Rotation
	private Quaternion quat;
	
	//Geschwindigkeitserhoehung
	public float speedBoost = 30;

	//maximale Geschwindigkeit
	private float maxspeed = 40.0F;

	//globale stats (zB. ob Steuerung aktiv)
	public stats stats;

	//
	public static float aktuelleXPosition;
	public static float aktuelleYPosition;

	//timer der runter zählt
	float timeLeft;

	//Fenster in dem sich das Taxi aufhaelt
	float xMin = -24.0F;
	float xMax = 328.0F;
	float yMin = -20.0F;
	float yMax = 224.0F;



	public static bool kommtAusLvl;

	//
	bool positionErfasst;
	
	void Start () {
		if (kommtAusLvl) {
			transform.position = new Vector2 (aktuelleXPosition, aktuelleYPosition);
			timeLeft = 1.0f;
		} else {
			//nicht nötig, aber zur Sicherheit: das taxi ist drehbar
			rigidbody2D.fixedAngle = false;	
			
			//start für timer setzen
			timeLeft = 1.0f;
			
			positionErfasst = false;
			Debug.Log ("wieder da");
		}

	}

	void Update () { 

////	STEUERUNG   ///
		/// 
		//falls Steuerung aktiv ist, kann das Taxi gesteuert werden, 
		//falls nicht (es befindet sich dann in einer Atmosphäre, nicht
		if (stats.istSteuerungAktiv ()) {
			positionErfasst = false;
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
		} else {
		//Posoition des Taxis erfassen, wenn es eine Atmospäre betritt
			if(!positionErfasst){
				positionErfasst = true;
				float xVelo = rigidbody2D.velocity.x;
				float yVelo = rigidbody2D.velocity.y;
				if(xVelo > 0){
					xVelo = 5;
				} else if (xVelo < 0){
					xVelo = -5;
				} 
				if(yVelo > 0){
					yVelo = 5;
				} else if (yVelo < 0){
					yVelo = -5;
				} 
				aktuelleXPosition = rigidbody2D.transform.position.x - xVelo;
				aktuelleYPosition = rigidbody2D.transform.position.y - yVelo;
			}

			// timer wird gestartet
			timeLeft -= Time.deltaTime;
			//je weiter der Timer runter zählt, desto stärker wird das Taxi abgebremst (drag)
			if (timeLeft > 0.2) {
				rigidbody2D.drag = 7.0f;
			} else if (timeLeft > 0.0f) {
				rigidbody2D.drag = 20.0f;
			} else if (timeLeft <= 0.0f){
				Debug.Log("index: " + stats.getLoadLevelIndex());
				Debug.Log("levelCount: " + Application.levelCount);
				if (Application.levelCount > stats.getLoadLevelIndex()) {
					kommtAusLvl = true;
					stats.setSteuerungAktiv(true);
					timeLeft = 1.0F;
					Application.LoadLevel(stats.getLoadLevelIndex());
				} else {
					transform.position = new Vector2 (aktuelleXPosition, aktuelleYPosition);
					stats.setSteuerungAktiv(true);
					timeLeft = 1.0F;
					rigidbody2D.drag = 0.0f;
				}
			} 
		}


////	TAXI IM UNIVERSUM HALTEN   ////
		/// 
		//collision rechts
		if (rigidbody2D.transform.position.x > xMax) {
			Debug.Log ("funktioniert1");
			transform.position = new Vector2 (xMax, rigidbody2D.transform.position.y);
			rigidbody2D.AddForce (new Vector2 (-speedBoost, 0));
			//stats.setSpeed(rigidbody2D.velocity.magnitude);
		} 
		//collision links
		if (rigidbody2D.transform.position.x < xMin) {
			Debug.Log ("funktioniert2");
			transform.position = new Vector2 (xMin, rigidbody2D.transform.position.y);
			rigidbody2D.AddForce (new Vector2 (speedBoost, 0));
			//stats.setSpeed(rigidbody2D.velocity.magnitude);
		}
		//collision oben
		if (rigidbody2D.transform.position.y > yMax) {
			Debug.Log ("funktioniert3");
			transform.position = new Vector2 (rigidbody2D.transform.position.x, yMax);
			rigidbody2D.AddForce (new Vector2 (0, -speedBoost));
			//stats.setSpeed(rigidbody2D.velocity.magnitude);
		} 
		//collision unten
		if (rigidbody2D.transform.position.y < yMin) {
			Debug.Log ("funktioniert4");
			transform.position = new Vector2 (rigidbody2D.transform.position.x, yMin);
			rigidbody2D.AddForce (new Vector2 (0, speedBoost));
			//stats.setSpeed(rigidbody2D.velocity.magnitude);
		}

		/*
		 * DAS BRAUCHEN WIR NICHT, WIR HABEN DOCH DEN ANIMATOR :P
		 */
////	TAXI KIPPEN    ////

		//   ___-9|...-3|---|3....|9___
		//Taxi, je nach Geschwindigkeit und Richtung, 
		//nach links und rechts kippen
		/*
		if (rigidbody2D.velocity.x < -9) {
			quat.Set (0.0F, 0.0f, 0.1F, 1.0f);
			transform.rotation = quat;
		} else if(rigidbody2D.velocity.x < -3 && rigidbody2D.velocity.x >= -9) {
			quat.Set(0.0F, 0.0f, 0.04F, 1.0f);
			transform.rotation = quat;
		} else if(rigidbody2D.velocity.x > 3 && rigidbody2D.velocity.x <= 9) {
			quat.Set(0.0F, 0.0f, -0.04F, 1.0f);
			transform.rotation = quat;
		} else if (rigidbody2D.velocity.x > 9) {
			quat.Set(0.0F, 0.0f, -0.1F, 1.0f);
			transform.rotation = quat;
		} else {
			quat.Set(0.0F, 0.0f, 0.0F, 1.0f);
			transform.rotation = quat;
		}
	*/


////	MAXIMALE GESCHWINDIGKEIT    ////

		if (rigidbody2D.velocity.magnitude > maxspeed) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxspeed;
		}
	}
}
