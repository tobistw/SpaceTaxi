using UnityEngine;
using System.Collections;

public class Welle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D other) {

		TaxiManager.instance.Damage = TaxiManager.instance.Damage - 8.0F;
		
	}
}
