using UnityEngine;
using System.Collections;

public class Levelspawn : MonoBehaviour {

	public Transform[] spawnPoints;
	public Rigidbody2D passenger;

	

	// Use this for initialization
	void Start () {

		int randomPoint = Random.Range (0, spawnPoints.Length);
		Debug.Log (randomPoint);

		if (randomPoint <= spawnPoints.Length) {
		
		Rigidbody2D instancePassenger = Instantiate (passenger, 
		                                           spawnPoints [randomPoint].position, 
		                                           spawnPoints [randomPoint].rotation) as Rigidbody2D;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
