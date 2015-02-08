using UnityEngine;
using System.Collections;

public class TaxiStop : MonoBehaviour {

	private int currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevel;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			PassengerManager.instance.checkLeavingTaxiGuest(currentLevel);
		}
	}
}
