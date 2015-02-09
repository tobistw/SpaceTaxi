using UnityEngine;
using System.Collections;

public class TaxiStop : MonoBehaviour {

	private int currentLevel;

	private bool isOnLandingZone;

	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevel;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		isOnLandingZone = true;
	}

	void OnTriggerExit2D(Collider2D coll) {
		isOnLandingZone = false;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && isOnLandingZone) {
			StartCoroutine(waitForLeavingGuests());
		}
	}

	IEnumerator waitForLeavingGuests() {
		yield return new WaitForSeconds(2f);
		PassengerManager.instance.checkLeavingTaxiGuest(currentLevel);
		isOnLandingZone = false;
	}
}
