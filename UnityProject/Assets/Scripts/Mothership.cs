using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {




	private LevelStats levelStats;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}
	}
	
	void Update() {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "taxi") {
			levelStats.IsMothershipActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "taxi") {
			levelStats.IsMothershipActive = false;
		}
	}

	
	
	
}
