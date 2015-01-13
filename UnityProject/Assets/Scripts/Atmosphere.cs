using UnityEngine;
using System.Collections;

public class Atmosphere : MonoBehaviour {

	private CircleCollider2D atmosphereCollider;

	// bestimmt das Level.
	public int levelIndex;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// Use this for initialization
	void Start () {
		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//wenn das Taxi die Atmospäre betritt, 
	//wird die steuerung des taxis deaktiviert
	void OnTriggerEnter2D (Collider2D other) {
			//stats.setSteuerungAktiv (false);
			Application.LoadLevel(levelIndex);

	}

	public int LevelIndex {
		get {
			return levelIndex;
		}

		set {
			levelIndex = value;
		}
	}
}
