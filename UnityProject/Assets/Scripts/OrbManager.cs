using UnityEngine;
using System.Collections;

public class OrbManager : MonoBehaviour
{
	//Here is a private reference only this class can access
	private static OrbManager _instance;

	//This is the public reference that other classes will use
	private static OrbManager instance {
		get {
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<OrbManager>();
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	// Holds the active Orbs.
	private ArrayList activeOrbs;


	void Awake() {

		if (_instance == null) {
			activeOrbs = new ArrayList();
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	public void addActiveOrb(Orb orb) {
		activeOrbs.Add (orb);
	}
}

