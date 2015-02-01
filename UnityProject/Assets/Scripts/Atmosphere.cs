using UnityEngine;
using System.Collections;

public class Atmosphere : MonoBehaviour {

	private CircleCollider2D atmosphereCollider;

	// bestimmt das Level. Jede Atmosphäre kennt seinen Level.
	public int levelIndex;

	// es werden die Level Stati verwaltet.
	private LevelStats levelStats;

	// Der Orb Manager
	public OrbManager orbManager;

	private Rigidbody2D taxi;

	// Use this for initialization
	void Start () {
		// Initalisierung der Levelstats
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();

			levelIndex = OrbManager.instance.getLevelIndex(this.name);

		} else {
			Debug.Log("Cant find Game Controller Object");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D other) {

		taxi = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

		//brauch man, damit das Taxi etwas versetzt wieder auftaucht, sonst lädt sich das lvl wieder
		float xVelo = taxi.velocity.x;
		float yVelo = taxi.velocity.y;

		if(xVelo > 0){
			xVelo = 5;
		} else if (xVelo < 0){
			xVelo = -5;
		} 
		if(yVelo > 0){
			yVelo = 5;
		} else if (yVelo < 0){
			yVelo = -5;
		} 

		levelStats.CurrentPosition = new Vector2(taxi.transform.position.x - xVelo, taxi.transform.position.y - yVelo);
	
		// Das Level wird geladen.
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
