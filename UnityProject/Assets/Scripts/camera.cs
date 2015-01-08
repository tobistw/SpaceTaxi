using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {


	public Rigidbody2D follow;

	
	void Start () {
	}

	void Update () {
	}
	
	void LateUpdate(){

		transform.position = new Vector3 (follow.transform.position.x , follow.transform.position.y, -3.0F);

	}
}