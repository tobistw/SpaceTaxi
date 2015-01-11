using UnityEngine;
using System.Collections;

public class SortPaticleSystem : MonoBehaviour {

	public string layerName = "Particles";

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = layerName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
