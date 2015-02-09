using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static MusicManager _instance;
	
	//This is the public reference that other classes will use
	public static MusicManager instance {
		get {
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<MusicManager>();
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}
	

	void Awake() {
		
		if (_instance == null) {
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

	public void SoundHeyTaxi() {
		audio.Play ();
	}
}
