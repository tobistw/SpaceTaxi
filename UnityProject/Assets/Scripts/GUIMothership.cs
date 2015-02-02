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
		currentBudget = TaxiManager.instance.Budget;
		currentFuel = TaxiManager.instance.Fuel;
		fuelDifference = TaxiManager.instance.FuelAmount - currentFuel;
		if ((fuelDifference * fuelPrice) <= currentBudget) {
			TaxiManager.instance.Budget = (int) Mathf.Round (currentBudget - (fuelDifference * fuelPrice));
			TaxiManager.instance.Fuel = TaxiManager.instance.FuelAmount;
		} else {
			float moeglicheliter = currentBudget/fuelPrice;
			TaxiManager.instance.Budget = (int) Mathf.Round (currentBudget - (moeglicheliter * fuelPrice));
			TaxiManager.instance.Fuel = currentFuel + moeglicheliter;
		}
	}

	public void ClickReparieren(){
		currentBudget = TaxiManager.instance.Budget;
		currentDmg = TaxiManager.instance.Damage;
		dmgDifference = TaxiManager.instance.Stability - currentDmg;
		if ((dmgDifference * dmgPrice) <= currentBudget) {
			TaxiManager.instance.Budget = (int) Mathf.Round (currentBudget - (dmgDifference * dmgPrice));
			TaxiManager.instance.Damage = TaxiManager.instance.Stability;
		} else {
			float moeglicheDMGpoints = currentBudget/dmgPrice;
			TaxiManager.instance.Budget = (int) Mathf.Round (currentBudget - (moeglicheDMGpoints * dmgPrice));
			TaxiManager.instance.Damage = currentDmg + moeglicheDMGpoints;
		}
	}


}
