using UnityEngine;
using System.Collections;

public class MapSpawn : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = (GameObject)Instantiate(Resources.Load("Player"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
