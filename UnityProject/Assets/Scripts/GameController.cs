using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int activeOrbs;

	public static GameObject[] atmosphereObjects;

	private CircleCollider2D atmosphereCollider;

	public static Atmosphere[] atmospheres;

	public static int defaultActiveOrbs = 2;

	public static int nextLevelBudget = 100;

	private bool isControlerAcitve;

	private bool isPlayerInMap;

	private static ArrayList orbInactiveList;

	private static ArrayList orbActiveList;

	private GameObject atmo;

	private Atmosphere atmoScript;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	private static bool isGameRunning;

	void Awake() {
		DontDestroyOnLoad (atmo);
	}

	void Start() {


		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		initActivePlanets ();

		firstGameRunning ();

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

			// Wähle - einmalig -  zufällig einen Planeten aus der Map aus.

			for(int i = 0; i < activeOrbs; i++) {

				int randomIndex = Random.Range(0, atmosphereObjects.Length - 1);

				orbActiveList.Add(orbInactiveList[randomIndex]);
				orbInactiveList.Remove(orbInactiveList[randomIndex]);

			}

		renderAtmospheres ();

	}

	// Methode zum Rendern der aktiven Atmosphären.
	void renderAtmospheres() {
		Debug.Log (orbActiveList.Count);
		for (int i = 0; i < orbActiveList.Count; i++) {
			Debug.Log((GameObject) orbActiveList[i]);
			atmo = (GameObject) orbActiveList[i];
			atmoScript = atmo.GetComponent<Atmosphere>();
			atmoScript.LevelIndex = i + 1;
			atmo.renderer.enabled = true;
			CircleCollider2D atmoCollider = atmo.GetComponent<CircleCollider2D>();
			atmo.renderer.enabled = true;
			atmoCollider.isTrigger = true;
			atmoCollider.enabled = true;
		}
	}

	// Wird nur einmal nach dem Start des Spiels ausgeführt.
	void firstGameRunning () {
		if (!isGameRunning) {
			

			orbInactiveList = new ArrayList ();
			orbActiveList = new ArrayList();

			atmosphereObjects = GameObject.FindGameObjectsWithTag ("atmosphere");

			// Inaktive Planeten werden vorinitialisiert...
			if (atmosphereObjects != null) {
				
				for(int i = 0; i < atmosphereObjects.Length; i++) {
					orbInactiveList.Add(atmosphereObjects[i]);
				}

			// Die aktiven Atmosphären werden nach erstem Start des Spiels aktiviert.

			initAtmospheres ();

			} else {
				
				Debug.Log("Cant find Game Atmosphere Object");
				
			}
			isGameRunning = true;
		
		} else {

			renderAtmospheres ();
		}
	}
}
