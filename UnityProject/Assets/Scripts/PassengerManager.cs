using UnityEngine;
using System.Collections;

public class PassengerManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static PassengerManager _instance;
	private  LevelStats levelStats;
	
	//This is the public reference that other classes will use
	public static PassengerManager instance {
		get {

			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<PassengerManager>();
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	// Verwaltet die Taxi Gäste
	private ArrayList taxiGuests;

	private GameController gameController;


	public GameObject guestSlot;
	
	public Sprite sprite;

	private SpriteRenderer spriteRenderer;

	void Awake() {

		if (_instance == null) {
			taxiGuests = new ArrayList ();
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
	 * Der zugestiegende Fahrgast wird in die Liste aufgenommen und Ziellevelname, Passagiertyp
	 * werden dem SpriteManager übegeben.
	 */
	public void setTaxiGuest(string name, int start, Level level, int money, int bonus, float timer) {
		if (taxiGuests.Count < TaxiManager.instance.PassengerCount) {
			Guest currentGuest = new Guest (name, start, level, money, bonus, timer);
			taxiGuests.Add (currentGuest);
			SpriteManager.instance.setRendererForDestination(level.AtmoName, name, taxiGuests.LastIndexOf(currentGuest));
		}
	}
	

	public void checkLeavingTaxiGuest(int destinationLevel) {

		Guest[] guests = new Guest[taxiGuests.Count];
		Guest currentGuest;

		for (int i = 0; i < guests.Length; i++) {
			guests[i] = (Guest) taxiGuests[i];
		}

		taxiGuests.Clear ();

		for (int i = 0; i < guests.Length; i++) {
			currentGuest = (Guest) guests[i];
			if (!(currentGuest.Level.LevelIndex == destinationLevel)) {
				taxiGuests.Add(currentGuest);
			} else {
				Debug.Log(currentGuest.Name + ": Fahrgeld: " + currentGuest.Money + " Bonus: " + currentGuest.Bonus);
				//TaxiManager das Budget gutschreiben.
				TaxiManager.instance.Budget += currentGuest.Money + currentGuest.Bonus;
				SpriteManager.instance.setDefaultRendererForDestination(null);
			}
		}

		// SpriteManager update mitteilen.
		refreshTaxiGuestList ();
	}

	/**
	 * Wird benötigt, um die Anzeige für die Fahrgäste bei Levelwechsel anzuzeigen.
	 */
	public void refreshTaxiGuestList() {
		if (taxiGuests.Count > 0) {
			foreach (Guest guest in taxiGuests) {
				SpriteManager.instance.setRendererForDestination(guest.Level.AtmoName, guest.Name, taxiGuests.LastIndexOf(guest));
			}
		} else {
			SpriteManager.instance.setDefaultRendererForDestination(null);
		}
	}

	public bool isPassengerStartLevel(int compareLevel) {
		bool isStartLevel = false;

		if (taxiGuests != null && taxiGuests.Count > 0) {
			foreach (Guest guest in taxiGuests) {
				if (guest.Startlevel == compareLevel) {
					isStartLevel = true;
					return isStartLevel;
				}
			}
		}
		return isStartLevel;
	}

	public void clearGuestList() {
		taxiGuests.Clear ();
	}

	private class Guest {

		string name;

		int startlevel;

		Level level;

		int money, bonus;

		float timer;

		public Guest (string name,int startlevel, Level level, int money, int bonus, float timer)
		{
			this.name = name;
			this.startlevel = startlevel;
			this.level = level;
			this.money = money;
			this.bonus = bonus;
			this.timer = timer;
		}

		public string Name {
			get {
				return this.name;
			}
			set {
				name = value;
			}
		}

		public int Startlevel {
			get {
				return this.startlevel;
			}
			set {
				startlevel = value;
			}
		}

		 public Level Level {
			get {
				return this.level;
			}
			set {
				level = value;
			}
		}

		public int Money {
			get {
				return this.money;
			}
			set {
				money = value;
			}
		}

		public int Bonus {
			get {
				return this.bonus;
			}
			set {
				bonus = value;
			}
		}

		public float Timer {
			get {
				return this.timer;
			}
			set {
				timer = value;
			}
		}
	}
}
