using UnityEngine;
using System.Collections;

public class stats : MonoBehaviour {

	//Steuerung des Taxis: aktiv oder nicht aktiv
	bool steuerungAktiv;
	
	public static GameObject[] atmosphaeren;
	public static CircleCollider2D[] atmoCollider;
	public static AtmosphaerenScript[] atmoScripts;
	private static int aktivePlaneten;
	private static bool aktivePlanetenChange;
	private int loadLevelIndex;

	void Start () {
		aktivePlanetenChange = true;
		aktivePlaneten = 2;
		atmosphaeren = GameObject.FindGameObjectsWithTag("atmosphaere");
		atmoCollider = new CircleCollider2D[atmosphaeren.Length];
		atmoScripts = new AtmosphaerenScript[atmosphaeren.Length];

		for (int i = 0; i < atmosphaeren.Length; i++) {
			atmosphaeren[i].renderer.enabled = false;

			atmoCollider[i] = atmosphaeren[i].GetComponent<CircleCollider2D>();
			atmoCollider[i].enabled = false;

			atmoScripts[i] = atmosphaeren[i].GetComponent<AtmosphaerenScript>();
			atmoScripts[i].SetIndex(i + 1);
		}

		steuerungAktiv = true;

	}

	void Update() {
		if (aktivePlanetenChange) {
			aktivePlanetenChange = false;
			for (int i = 0; i < aktivePlaneten; i++) {
				atmosphaeren[i].renderer.enabled = true;
				atmoCollider[i].enabled = true;
				atmoCollider[i].isTrigger = true;
				atmoCollider[i].renderer.enabled = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.N)) {
			aktivePlanetenChange = true;
			aktivePlaneten++;
		}
	}

	//gibt zurück ob Steuerung des Taxis aktiv ist
	public bool istSteuerungAktiv(){
		return steuerungAktiv;
	}

	//setzt Aktivität des Taxis
	public void setSteuerungAktiv(bool steuerungAktiv){
		this.steuerungAktiv = steuerungAktiv;
	}

	public void seLoadLevelIndex(int i){
		loadLevelIndex = i;
	}

	public int getLoadLevelIndex(){
		return loadLevelIndex;
	}

}
