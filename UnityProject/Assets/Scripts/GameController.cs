using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int activeOrbs;

	public static GameObject[] atmosphereObjects;

	public static GameObject[] orbObjects;

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
	void initOrbs () {

			// Wähle - einmalig -  zufällig Planeten aus der Map aus.

		for(int i = 0; i < activeOrbs; i++) {

			int randomIndex = Random.Range(0, orbObjects.Length - 1);

			GameObject gameObjectOrb = (GameObject) orbInactiveList[randomIndex];
			Debug.Log(gameObjectOrb.name);
			Orb orb = gameObjectOrb.GetComponent<Orb>();
			orb.IsActive = true;
			orbActiveList.Add(gameObjectOrb);

			orbInactiveList.Remove(orbInactiveList[randomIndex]);

			}

	}

	// Wird nur einmal nach dem Start des Spiels ausgeführt.
	void firstGameRunning () {
		if (!isGameRunning) {
			

			orbInactiveList = new ArrayList ();
			orbActiveList = new ArrayList();

			orbObjects = GameObject.FindGameObjectsWithTag("Orb");

			// Inaktive Planeten werden vorinitialisiert...
			if (orbObjects != null) {
				
				for(int i = 0; i < orbObjects.Length; i++) {
					orbInactiveList.Add(orbObjects[i]);
				}

			// Die aktiven Planeten werden nach erstem Start des Spiels ausgesucht.

			initOrbs ();

			} else {
				
				Debug.Log("Cant find Game Atmosphere Object");
				
			}
			isGameRunning = true;
		
		}
	}
}
