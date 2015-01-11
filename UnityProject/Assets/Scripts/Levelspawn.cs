using UnityEngine;
using System.Collections;

public class Levelspawn : MonoBehaviour {

	public Transform[] spwanPoints;
	public Rigidbody2D passenger;

	

	// Use this for initialization
	void Start () {

		int randomPoint = Random.Range (0, spwanPoints.Length);
		Debug.Log (randomPoint);

		Rigidbody2D instancePassenger = Instantiate (passenger, 
		                                           spwanPoints [randomPoint].position, 
		                                           spwanPoints [randomPoint].rotation) as Rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
