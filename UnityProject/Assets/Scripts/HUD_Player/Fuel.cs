using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fuel : MonoBehaviour {

	private Text text;
	
	
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		initPlayerPreferences ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.M)) {
			
			PlayerPrefs.SetInt ("Fuel", 40);
		}
		
		text.text = PlayerPrefs.GetInt ("Fuel") + " l";
	}
	
	void initPlayerPreferences() {
	}
}
