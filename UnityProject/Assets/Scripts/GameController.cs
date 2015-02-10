using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int numberOfActiveOrbs;

	public static GameObject[] atmosphereObjects;

	public static GameObject[] orbObjects;

	private CircleCollider2D atmosphereCollider;

	public static Atmosphere[] atmospheres;

	public static int defaultNumberOfActiveOrbs = 2;

	public static int nextLevelBudget = 150;

	private bool isControlerAcitve;

	private bool isPlayerInMap;

	private bool isNewLevelReached;

	private static ArrayList orbInactiveList;

	private static ArrayList orbActiveList;

	private GameObject atmo;

	private Atmosphere atmoScript;

	private static bool isGameRunning;

	// Die Taxiwerte für die Map.
	public float speedBoost, maxSpeed, gravity;
	

	void Start() {

		if (TaxiManager.instance.hasNewGameStarted()) {
			Debug.Log("new Game started");
			resetGameController();
			TaxiManager.instance.toggleNewGameStarted();
		}

		orbInactiveList = new ArrayList ();
		orbActiveList = new ArrayList();
		gravity = 0;

		TaxiManager.instance.gravity = gravity;
		TaxiManager.instance.speedBoost = speedBoost;
		TaxiManager.instance.gravity = gravity;

		initActiveOrbs ();

		firstGameRunning ();

	}
	

	/**
	 * Es wird die Anzahl aktiver Planeten ermittelt.
	 * */
	void initActiveOrbs() {

		int currentBudget = TaxiManager.instance.Budget;
		// Wurde bereits das Budget für ein neues Level erreicht.
		if (TaxiManager.instance.IsNewLevelReached) {
			TaxiManager.instance.IsNewLevelReached = false;
						// neue Level hinzufügen
			Debug.Log("Neues Level, ingesamt: " + OrbManager.instance.NumberOfActiveOrbs);
			// Level Stats aktualisieren!!
			setNextActiveOrb();
		} 
	}

	/**
	 * Die Atmosphären der aktiven Planeten werden aktiviert.
	 * */
	void initOrbs () {

			// Wähle - einmalig -  zufällig Planeten aus der Map aus.

		for(int i = 0; i < numberOfActiveOrbs; i++) {

			int randomIndex = Random.Range(0, orbObjects.Length - 1);

			GameObject gameObjectOrb = (GameObject) orbInactiveList[randomIndex];
			// Der aktive Planet wird gesetzt.
			gameObjectOrb.GetComponent<Orb>().IsActive = true;
			// Das Level wird zugewiesen.
			OrbManager.instance.setLevelIndex(gameObjectOrb.name, 
			                                  gameObjectOrb.GetComponentInChildren<Atmosphere>().name,
			                                  i + 2);
			orbActiveList.Add(gameObjectOrb);

			// Aktive Planeten werden aus der Inaktiv Liste rausgeschmissen.
			orbInactiveList.Remove(orbInactiveList[randomIndex]);

			}
	}


	// Wird nur einmal nach dem Start des Spiels ausgeführt.
	void firstGameRunning () {
		if (!isGameRunning) {

			numberOfActiveOrbs = defaultNumberOfActiveOrbs;
			// In den OrbManager schreiben.
			OrbManager.instance.NumberOfActiveOrbs = numberOfActiveOrbs;

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

	void setNextActiveOrb() {
		ArrayList activeOrbNames = OrbManager.instance.getActiveOrbs ();
		orbObjects = GameObject.FindGameObjectsWithTag("Orb");
		
		// Inaktive Planeten werden vorinitialisiert...
		if (orbObjects != null) {
			
			for(int i = 0; i < orbObjects.Length; i++) {
				if (activeOrbNames.Contains(orbObjects[i].name)) {
					orbActiveList.Add(orbObjects[i]);
				} else {
					orbInactiveList.Add(orbObjects[i]);
				}
			}
			if (orbInactiveList.Count > 0) {
				Debug.Log("Neues Level");
				orbActiveList.Add(orbInactiveList[0]);
				GameObject goOrb = (GameObject) orbActiveList[orbActiveList.Count - 1];
				goOrb.GetComponent<Orb>().isActive = true;
				OrbManager.instance.setLevelIndex(goOrb.name, 
				                                  goOrb.GetComponentInChildren<Atmosphere>().name,
				                                  orbActiveList.Count + 1);
			}
		}
	}


	public void resetGameController() {
		orbActiveList.Clear ();
		orbInactiveList.Clear ();
		isGameRunning = false;
	}


}
