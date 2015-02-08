using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static SpriteManager _instance;
	
	//This is the public reference that other classes will use
	public static SpriteManager instance {
		get {
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<SpriteManager>();
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public Sprite defaultGuest, defaultOrb;

	public Sprite[] spriteOrbs = new Sprite[6];
	public Sprite[] spriteGuests = new Sprite[3];

	private SpriteRenderer[] rGuestSlots = new SpriteRenderer[5];

	private SpriteRenderer[] rOrbSlots = new SpriteRenderer[5];

	
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

	void Start() {

		initGameObjectsRenderer ();
	}

	public void setRendererForDestination(string destinationOrb, string passengerName, int slot) {

		initGameObjectsRenderer ();

		for (int i = 0; i < spriteOrbs.Length; i++) {
			if (spriteOrbs[i].name.Equals(destinationOrb)) {
				rOrbSlots[slot].sprite = spriteOrbs[i];
				break;
			}
		}

		for (int i = 0; i < spriteGuests.Length; i++) {
			if (spriteGuests[i].name.Equals(passengerName)) {
				rGuestSlots[slot].sprite = spriteGuests[i];
				break;
			}
		}
	}


	private void initGameObjectsRenderer() {

		rGuestSlots[0] = GameObject.Find ("guest_slot1").GetComponent<SpriteRenderer>();
		rGuestSlots[1] = GameObject.Find ("guest_slot2").GetComponent<SpriteRenderer>();
		rGuestSlots[2] = GameObject.Find ("guest_slot3").GetComponent<SpriteRenderer>();
		rGuestSlots[3] = GameObject.Find ("guest_slot4").GetComponent<SpriteRenderer>();
		rGuestSlots[4] = GameObject.Find ("guest_slot5").GetComponent<SpriteRenderer>();

//		for (int i = 0; i < rGuestSlots.Length; i++) {
//			rGuestSlots[i].sprite = defaultGuest;
//		}

		rOrbSlots[0] = GameObject.Find ("dst_planet1").GetComponent<SpriteRenderer>();
		rOrbSlots[1] = GameObject.Find ("dst_planet2").GetComponent<SpriteRenderer>();
		rOrbSlots[2] = GameObject.Find ("dst_planet3").GetComponent<SpriteRenderer>();
		rOrbSlots[3] = GameObject.Find ("dst_planet4").GetComponent<SpriteRenderer>();
		rOrbSlots[4] = GameObject.Find ("dst_planet5").GetComponent<SpriteRenderer>();

//		for (int i = 0; i < rGuestSlots.Length; i++) {
//			rOrbSlots[i].sprite = defaultOrb;
//		}
	}
}
