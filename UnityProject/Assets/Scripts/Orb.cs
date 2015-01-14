using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	public static GameObject atmosphereObject;
	
	private CircleCollider2D atmosphereCollider;
	
	public static Atmosphere[] atmospheres;

	// Jeder Planet weiß, ob er aktiv ist.
	public bool isActive;

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

		renderAtmosphere ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* Die Atmosphäre wird gerendert, sobald der Planet auf aktiv gesetzt wurde.
	 * 
	 * */
	void renderAtmosphere() {

		// Der aktive Planet wird über die LevelStats ermittelt. Das wird dafür benötigt, 
		// wenn das Map Level erneut geladen wird.
		if (levelStats.activeOrbInPrefs(this.name) == this.name){
			isActive = true;
		}

		// hier wird gerendert.
		if (isActive) {

			// Hier wird der aktive Planet in den LevelStats (PlayerPrefs) gespeichert.
			levelStats.ActiveOrbName = this.name;

			atmosphereObject = transform.GetChild(0).gameObject;
			atmosphereCollider = atmosphereObject.GetComponent<CircleCollider2D>();

			atmosphereObject.renderer.enabled = true;
			atmosphereCollider.enabled = true;
			atmosphereCollider.isTrigger = true;
		}
	}


	// Getter und Setter

	public bool IsActive {

		get {
			return isActive;
		}

		set {
			isActive = value;
		}
	}
	
}
