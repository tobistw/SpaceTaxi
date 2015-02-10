using UnityEngine;
using System.Collections;

public class Wasser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log("plascth");
		TaxiManager.instance.Damage = -0.1F;
		
	}
}
