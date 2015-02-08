using UnityEngine;
using System.Collections;

public class Umweltschrott : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.name == "taxi") {
			if (collision.relativeVelocity.magnitude > 5) {
				TaxiManager.instance.Damage = TaxiManager.instance.Damage - collision.relativeVelocity.magnitude;
			}
		}
		
		//Debug.Log (PlayerPrefs.GetFloat ("Damage"));
		//Debug.Log (collision.relativeVelocity.magnitude);
		//if (collision.relativeVelocity.magnitude > 2)
		//	audio.Play();
		
	}
}
