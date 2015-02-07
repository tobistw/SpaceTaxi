using UnityEngine;
using System.Collections;

public class PassengerManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static PassengerManager _instance;
	
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
	

	public void setTaxiGuest(string name, Level level, int money, int bonus, float timer) {
		if (taxiGuests.Count < TaxiManager.instance.PassengerCount) {
			Guest currentGuest = new Guest (name, level, money, bonus, timer);
			taxiGuests.Add (currentGuest);

			SpriteManager.instance.setRendererForDestination(level.AtmoName, taxiGuests.LastIndexOf(currentGuest));
		}


	}

	private class Guest {

		string name;

		Level level;

		int money, bonus;

		float timer;

		public Guest (string name, Level level, int money, int bonus, float timer)
		{
			this.name = name;
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
