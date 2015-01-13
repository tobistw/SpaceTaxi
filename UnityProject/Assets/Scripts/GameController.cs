using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int activeOrbs;

	public GameObject[] atmosphereObjects;

	private CircleCollider2D atmosphereCollider;

	public static Atmosphere[] atmospheres;

	public static int defaultActiveOrbs = 2;

	public static int nextLevelBudget = 100;

	private bool isControlerAcitve;

	private bool isPlayerInMap;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;


	void Start() {

		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		initActivePlanets ();

		initAtmospheres ();
	}

	/**
	 * Es wird die Anzahl aktiver Planeten ermittelt.
	 * */
	void initActivePlanets() {

		int currentBudget = levelStats.Budget;
		// Wurde bereits das Budget für ein neues Level erreicht.
		if (currentBudget > nextLevelBudget) {
						// neue Level hinzufügen
		} else {
			activeOrbs = defaultActiveOrbs;
		}
	}

	/**
	 * Die Atmosphären der aktiven Planeten werden aktiviert.
	 * */
	void initAtmospheres () {
		// Array mit Atmosphären der Planeten
		//atmosphereObjects = GameObject.FindGameObjectsWithTag ("atmosphere");

		if (atmosphereObjects != null) {
			// Wähle - einmalig -  zufällig einen Planeten aus der Map aus.
			/*
			for(int i = 0; i < activeOrbs; i++) {

				int randomIndex = Random.Range(0, levelStats.atmosphereObjects.Length);

				// Prüfe die Hashmap: Wurde der Planet noch nicht aktiviert?
				int value = levelStats.activeOrbTable.Values;
				if (value == 0) {
					// Aktiviere die Atmosphäre...
					levelStats.atmosphereObjects[randomIndex].renderer.enabled = true;
					atmosphereCollider = levelStats.atmosphereObjects[randomIndex].GetComponent<CircleCollider2D>();
					atmosphereCollider.renderer.enabled = true;
					atmosphereCollider.isTrigger = true;
					atmosphereCollider.enabled = true;
					//...und schreibe es in die Hashtable
					levelStats.activeOrbTable.Add(randomIndex, 1);
					Debug.Log("Hashtable Size:" + levelStats.activeOrbTable.Count);
				} 
					//....
			}
			*/

			levelStats.atmosphereObjects[0].renderer.enabled = true;
			atmosphereCollider = levelStats.atmosphereObjects[0].GetComponent<CircleCollider2D>();
			atmosphereCollider.renderer.enabled = true;
			atmosphereCollider.isTrigger = true;
			atmosphereCollider.enabled = true;

		} else {
			Debug.Log("Cant find Game Atmosphere Object");
		}

	}
}
