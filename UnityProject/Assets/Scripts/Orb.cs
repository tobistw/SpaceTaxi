using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	public static GameObject atmosphereObject;
	
	private CircleCollider2D atmosphereCollider;
	
	public static Atmosphere[] atmospheres;

	public static bool isActive;

	// Use this for initialization
	void Start () {
		renderAtmosphere ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void renderAtmosphere() {
		Debug.Log ("Planet: " + isActive);
		if (isActive) {

			atmosphereObject = this.GetComponentInChildren();
			Debug.Log(atmosphereObject.name);
//			atmosphereCollider = atmosphereObject.GetComponent<CircleCollider2D>();
//
//			atmosphereObject.renderer.enabled = true;
//			atmosphereCollider.enabled = true;
//			atmosphereCollider.isTrigger = true;
		}
	}

	public bool IsActive {

		get {
			return isActive;
		}

		set {
			isActive = value;
		}
	}
}
