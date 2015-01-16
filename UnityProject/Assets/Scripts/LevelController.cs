using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Festgelegte Punkte an denen die Passagiere erscheinen.
	public Transform[] spawnPoints;

	// Passagiere im Inspector hier rein ziehen.
	public Transform[] passengers;

	// Anzahl der Passagiere. Zum Testen Public. >>>>>>!!!Wird später aus Levelstats ermittelt!!!<<<<<
	public int passengerCount;

	// Hier kommen die Passagiere rein.
	private ArrayList passengerPrefabs;

	// Liste zum merken der noch verfügbaren Spwan Punkte.
	private ArrayList spawnPointList;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// Use this for initialization
	void Start () {

		passengerPrefabs = new ArrayList ();
		spawnPointList = new ArrayList ();

		
		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
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

		// Levelstats nach der Passagieranzahl abfragen.

		// solange Passagiere zufällig auswählen bis die Anzahl erreicht ist.
		for (int i = 0; i < passengerCount; i++) {
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
			Debug.Log("Index: " + randomSpawnPointIndex);

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

		Debug.Log (spawnPointList.Count);
		spawnPointList.Remove(spawnPoint);


	}
}
