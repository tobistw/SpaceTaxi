using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIMothership : MonoBehaviour {

	private LevelStats levelStats;
	private Canvas canvas;

	private int currentBudget;
	private float currentFuel;
	private float currentDmg;
	private float fuelDifference;
	private float dmgDifference;
	private float fuelPrice;
	private float dmgPrice;

	// Use this for initialization
	void Start () {

		fuelPrice = 1.2F;
		dmgPrice = 0.1F;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}
		canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelStats.IsMothershipActive) {
			canvas.enabled = true;
		} else {
			canvas.enabled = false;
		}
	}

	public void ClickAuftanken(){
		currentBudget = levelStats.Budget;
		currentFuel = levelStats.Fuel;
		fuelDifference = levelStats.FuelVolume - currentFuel;
		if ((fuelDifference * fuelPrice) <= currentBudget) {
			levelStats.Budget = (int) Mathf.Round (currentBudget - (fuelDifference * fuelPrice));
			levelStats.Fuel = levelStats.FuelVolume;
		} else {
			float moeglicheliter = currentBudget/fuelPrice;
			levelStats.Budget = (int) Mathf.Round (currentBudget - (moeglicheliter * fuelPrice));
			levelStats.Fuel = currentFuel + moeglicheliter;
		}
	}

	public void ClickReparieren(){
		currentBudget = levelStats.Budget;
		currentDmg = levelStats.Damage;
		dmgDifference = levelStats.Stability - currentDmg;
		if ((dmgDifference * dmgPrice) <= currentBudget) {
			levelStats.Budget = (int) Mathf.Round (currentBudget - (dmgDifference * dmgPrice));
			levelStats.Damage = levelStats.Stability;
		} else {
			float moeglicheDMGpoints = currentBudget/dmgPrice;
			levelStats.Budget = (int) Mathf.Round (currentBudget - (moeglicheDMGpoints * dmgPrice));
			levelStats.Damage = currentDmg + moeglicheDMGpoints;
		}
	}


}
