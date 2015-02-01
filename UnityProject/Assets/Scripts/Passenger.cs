using UnityEngine;
using System.Collections;

public class Passenger : MonoBehaviour {

	public int money, bonus;
	
	public float timer;

	private int currentLevel;

	private Level targetLevel;

	private ArrayList levelList;


	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevel;
		// hole alle aktiven Planeten.
		chooseDestination ();

	}


	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.tag == "Player") {
			StartCoroutine(enterTaxi ());
		}
	}


	/**
	 * Der Passagier sucht sich zufällig einen aktiven Planeten.
	 */
	private void chooseDestination() {
		Level[] possibleLevel;
		// schreibe alle möglichen Ziellevel in ein Array, außer das Aktuelle.
		levelList = (ArrayList) OrbManager.instance.getLevelList();
		possibleLevel = new Level[levelList.Count - 1];

		int j = 0;
		for (int i = 0; i < levelList.Count; i++) {
			targetLevel = (Level) levelList[i];
			if (targetLevel.LevelIndex != currentLevel) {
				possibleLevel[j] = targetLevel;
				j++;
			}
		}

		// Test der Ziellevel
		for (int i = 0; i < possibleLevel.Length; i++) {
			if (possibleLevel[i] != null) {
				Debug.Log(possibleLevel[i].AtmoName);
			} else {
				Debug.Log("null");
			}
		}

		// zufällige Auswahl des Zielplaneten.
		targetLevel = possibleLevel[Random.Range(0, possibleLevel.Length - 1)];
		Debug.Log ("Passagier: " + this.name + "; Zielplanet: " + targetLevel.AtmoName);

		Debug.Log ("Money: " + money + "; Bonus: " + bonus + "; Timer: " + timer);

	}

	/**
	 * Wenn das Taxi gelandet ist, kann der Passagier zusteigen.
	 */ 
	private IEnumerator enterTaxi() {
		// speichere Ziellevel und Passagiertyp mit Attributen im Passagiermanager.
		PassengerManager.instance.setTaxiGuest (this.name, targetLevel, money, bonus, timer);

		Destroy (gameObject, 2f);
		yield return new WaitForSeconds (3f);
	}
}
