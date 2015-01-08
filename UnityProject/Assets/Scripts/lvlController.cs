using UnityEngine;
using System.Collections;

public class lvlController : MonoBehaviour {

	//noetig für Rotation
	private Quaternion quat;
	
	//Geschwindigkeitserhoehung
	public float speedBoost = 15;
	
	//maximale Geschwindigkeit
	private float maxspeed = 24.0F;

	//timer der runter zählt
	float timeLeft;

	//ist steuerung aktiv
	bool steuerungAktiv;

	//Fenster in dem sich das Taxi aufhaelt
	float xMin = -17.2F;
	float xMax = 17.2F;
	float yMin = -20.0F;
	float yMax = 20.0F;
	
	//
	bool positionErfasst;
	
	void Start () {
		//nicht nötig, aber zur Sicherheit: das taxi ist drehbar
		rigidbody2D.fixedAngle = false;	

		steuerungAktiv = false;
		//start für timer setzen
		timeLeft = 0.5f;
	}
	
	void Update () { 
				
////	STEUERUNG   ///
		/// 
		//falls Steuerung aktiv ist, kann das Taxi gesteuert werden, 
		//falls nicht (es befindet sich dann in einer Atmosphäre, nicht
		if (steuerungAktiv) {			
			if (rigidbody2D.transform.position.y < 16.3F) {
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
				timeLeft -= Time.deltaTime;
				rigidbody2D.gravityScale = -0.5F;
				//je weiter der Timer runter zählt, desto stärker wird das Taxi abgebremst (drag)
				if (timeLeft <= 0.0f) {
					Application.LoadLevel (0);
				}
			}
		} else {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0.0f){
				rigidbody2D.gravityScale = 1.0f;
				steuerungAktiv = true;
				timeLeft = 0.8f;
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

		
		////	TAXI KIPPEN    ////
		
		//   ___-9|...-3|---|3....|9___
		//Taxi, je nach Geschwindigkeit und Richtung, 
		//nach links und rechts kippen
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
		
		
		////	MAXIMALE GESCHWINDIGKEIT    ////
		
		if (rigidbody2D.velocity.magnitude > maxspeed) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxspeed;
		}
	}
}
