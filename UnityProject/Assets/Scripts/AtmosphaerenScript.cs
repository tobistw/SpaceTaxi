using UnityEngine;
using System.Collections;

public class AtmosphaerenScript : MonoBehaviour {

	//globale stats (zB. ob Steuerung aktiv)
	public stats stats;
	private bool triggerAktiv;
	private CircleCollider2D cc;
	public int index;

	public float leftTime;



	void Start () {
		cc = this.GetComponent<CircleCollider2D>();
		cc.isTrigger = false;
		leftTime = 2.5f;
	}

	void Update () {
		//beim lvlup

	}

	//wenn das Taxi die Atmospäre betritt, 
	//wird die steuerung des taxis deaktiviert
	void OnTriggerEnter2D (Collider2D other) {
		if (cc.isTrigger == true) {
			stats.setSteuerungAktiv (false);
			stats.seLoadLevelIndex (index);
			Debug.Log("index aus objekt: " + index);
		}
	}

	public void SetIndex(int i){
		index = i;
	}



}
