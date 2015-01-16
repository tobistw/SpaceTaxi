using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {

	private Text text;


	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		initPlayerPreferences ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.N)) {

			PlayerPrefs.SetInt ("Budget", 200);
		}

		text.text = PlayerPrefs.GetInt ("Budget") + " $";
	}

	void initPlayerPreferences() {
	}
}
