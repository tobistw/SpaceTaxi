﻿using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {


//	private bool isPlayerLanded;

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
		if (other.gameObject.tag == "Player") {
			levelStats.IsMothershipActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			levelStats.IsMothershipActive = false;
		}
	}

//	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Player") {
//			isPlayerLanded = true;
//		}
//	}

//	void OnCollisionExit2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Player") {
//			levelStats.IsMothershipActive = false;
//			isPlayerLanded = false;
//		}
//	}
}
