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

	private int numberOfActiveOrbs;

	//Level Indexe werden zu den zugehörigen Planeten verwaltet.
	private Hashtable levelIndexTable;

	void Awake() {

		if (_instance == null) {
			activeOrbs = new ArrayList();
			levelIndexTable = new Hashtable();
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

	/**
	 * Zuständig für die Verwaltung aktiver Planetennamen.
	 */
	public void addActiveOrb(string orbName) {
		activeOrbs.Add (orbName);
	}

	public ArrayList getActiveOrbs() {
		return activeOrbs;
	}

	/**
	 * Durchsucht die aktive Planetennamenssammlung nach Treffern.
	 */
	public bool isInActiveOrbs(string name) {
		return activeOrbs.Contains (name);
	}

	public int NumberOfActiveOrbs {
		get {
			numberOfActiveOrbs = activeOrbs.Count;
			return numberOfActiveOrbs;
		}
		
		set {
			numberOfActiveOrbs = value;
		}
	}

	/**
	 * Zu dem Atmosphärennamen wird der Levelindex eingetragen.
	 */
	public void setLevelIndex(string name, int level) {
		levelIndexTable.Add (name, level);
	}

	public int getLevelIndex(string name) {
		int level = 0;
		if (levelIndexTable.ContainsKey(name)) {
			level = (int)(levelIndexTable[name]);
		}
		return level;
	}
}

