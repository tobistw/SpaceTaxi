using UnityEngine;
using System.Collections;

public class OrbManager : MonoBehaviour
{
	//Here is a private reference only this class can access
	private static OrbManager _instance;
	private  LevelStats levelStats;


	//This is the public reference that other classes will use
	public static OrbManager instance {
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

	// Beinhaltet die aktiven Planeten im aktuellen Spiel.
	private ArrayList activeOrbs;

	// Direkter Zugriff auf die Anzahl aktiver Planeten.
	private int numberOfActiveOrbs;

	private GameController gameController;



	//Level Indexe mit Passagieranzahl werden für die zugehörigen Planeten verwaltet.
	private Hashtable levelIndexPassengerTable;

	// beinhaltet Objekte der Klasse Level.
	private ArrayList levelList;

	void Awake() {

		if (_instance == null) {
			activeOrbs = new ArrayList();
			levelList = new ArrayList();
			levelIndexPassengerTable = new Hashtable();
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

	/**
	 * Für Abfragen nach der Anzahl aktiver Planeten.
	 */
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
	 * Zu einem Atmosphärennamen wird der Levelindex eingetragen.
	 */
	public void setLevelIndex(string orbName, string atmoName, int levelIndex) {
		levelList.Add( new Level(orbName, atmoName, levelIndex));
	}

	public ArrayList getLevelList() {
		return levelList;
	}

	/**
	 * Vergleicht den Namen der Atmosphäre mit der in der Levelliste und gibt den Levelindex.
	 */
	public int getLevelIndex(string name) {
		int level = 0;
		foreach (Level levelObj in levelList) {
			if (levelObj.AtmoName.Equals(name)) {
				level = levelObj.LevelIndex;
			}
		}
		return level;
	}

	/**
	 * Passagiere auf den Planeten merken.
	 */
	public void setPassengersOnOrb(int level, int passengers) {
		if (levelIndexPassengerTable.ContainsKey (level)) {
			levelIndexPassengerTable.Remove(level);
			levelIndexPassengerTable.Add(level, passengers);
		} else {
			levelIndexPassengerTable.Add (level, passengers);
		}
	}

	public int getPassengersOnOrb(int level) {
		int passengers = 0;
		if (levelIndexPassengerTable.ContainsKey(level)) {
			passengers = (int) (levelIndexPassengerTable[level]);
		}
		return passengers;
	}
	
}

