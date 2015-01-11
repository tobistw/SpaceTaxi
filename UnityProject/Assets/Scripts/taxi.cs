using UnityEngine;
using System.Collections;

public class taxi : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float fly = Input.GetAxis ("Horizontal");

		animator.SetFloat ("SpeedLeft", fly);
		animator.SetFloat ("SpeedRight", fly);


	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "boden") {
			animator.SetTrigger("Landing");
		}
	}

	void OnTriggerExit2D (Collider2D coll) {
		animator.SetTrigger ("Starting");
	}
}
