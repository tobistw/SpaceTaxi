using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int activeOrbs;

	public static GameObject[] atmosphereObjects;

	public static CircleCollider2D[] atmosphereCollider;

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

		// Wurde bereits das Budget für ein neues Level erreicht.
		int currentBudget = levelStats.Budget;

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
		atmosphereObjects = GameObject.FindGameObjectsWithTag ("atmosphere");

		if (atmosphereObjects != null) {
			atmosphereCollider = new CircleCollider2D[atmosphereObjects.Length];
			atmospheres = new Atmosphere[atmosphereObjects.Length];

			for (int i = 0; i < atmosphereObjects.Length; i++) {
				atmosphereObjects[i].renderer.enabled = false;
				atmosphereCollider[i] = atmosphereObjects[i].GetComponent<CircleCollider2D>();
				atmosphereCollider[i].enabled = false;

				atmospheres[i] = atmosphereObjects[i].GetComponent<Atmosphere>();
			}

			for (int i = 0; i < activeOrbs; i++) {
				atmosphereObjects[i].renderer.enabled = true;
				atmosphereCollider[i].renderer.enabled = true;
				atmosphereCollider[i].isTrigger = true;
				atmosphereCollider[i].enabled = true;
			}


		} else {
			Debug.Log("Cant find Game Atmosphere Object");
		}

	}
}
