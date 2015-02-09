using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Festgelegte Punkte an denen die Passagiere erscheinen.
	public Transform[] spawnPoints;

	// Passagiere im Inspector hier rein ziehen.
	public Transform[] passengers;

	// Anzahl der Passagiere. Zum Testen Public. >>>>>>!!!Wird später aus Levelstats ermittelt!!!<<<<<
	public int passengerCountOnOrb;

	// Hier kommen die Passagiere rein.
	private ArrayList passengerPrefabs;

	// Liste zum merken der noch verfügbaren Spwan Punkte.
	private ArrayList spawnPointList;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// im welchem Level befindet sich der Spieler.
	private int level;

	// Der Orb Manager
	public OrbManager orbManager;

	// Die Taxiwerte für das Level.
	public float speedBoost, maxSpeed, gravity;

	private SpriteRenderer rTaxiMinimap;

	// Use this for initialization
	void Start () {

		level = Application.loadedLevel;

		passengerPrefabs = new ArrayList ();
		spawnPointList = new ArrayList ();

		TaxiManager.instance.gravity = gravity;
		TaxiManager.instance.speedBoost = speedBoost;
		TaxiManager.instance.gravity = gravity;
		
		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		GameObject gameObjectTaxi = GameObject.FindGameObjectWithTag ("taxiMinimap");
		
		if (gameControllerObject != null && gameObjectTaxi != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
			rTaxiMinimap = gameObjectTaxi.GetComponent<SpriteRenderer>();

			rTaxiMinimap.enabled = false;
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		randomPassengerChoose ();

		spawnPassenger ();
	}


	/**
	 * Erst wird die möglich Passagieranzahl ermittelt, dann zufällig Passagiere ausgewählt. 
	 */
	void randomPassengerChoose() {

		// OrbManager nach der Passagieranzahl abfragen. Wird über den Level Index referenziert.
		passengerCountOnOrb = OrbManager.instance.getPassengersOnOrb (level);

		// solange Passagiere zufällig auswählen bis die Anzahl erreicht ist.
		for (int i = 0; i < passengerCountOnOrb; i++) {
			passengerPrefabs.Add(passengers[Random.Range(0, passengers.Length - 1)]);
		}

	}


	/**
	 * Passagiere werden auf zufällig ausgewählten Punkten gespawnt.
	 */
	private void spawnPassenger() {

		int randomSpawnPointIndex;


		foreach (Transform point in spawnPoints) {
			spawnPointList.Add(point);
		}
			 
		foreach (Transform passenger in passengerPrefabs) {

			randomSpawnPointIndex = Random.Range (0, spawnPointList.Count - 1);

			if (spawnPointList.Count > 1 && randomSpawnPointIndex != -1) {

				instantiatePassenger(passenger, randomSpawnPointIndex);

			} else {

				if (spawnPointList.Count == 1) {
					instantiatePassenger(passenger, 0);
					break;
				} 
				instantiatePassenger(passenger, 0);
			}
		}
	}

	/**
	 * Methode zum spawnen der Passagiere.
	 */
	void instantiatePassenger(Transform passenger, int index) {
		Transform spawnPoint;

		spawnPoint = (Transform) spawnPointList[index];
		Instantiate(passenger, spawnPoint.position, spawnPoint.rotation);
		
		spawnPointList.Remove(spawnPoint);


	}
}
