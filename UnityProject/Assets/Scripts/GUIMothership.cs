using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIMothership : MonoBehaviour {

	private LevelStats levelStats;
	private Canvas canvasMothership;


	private int currentBudget;
	private float currentFuel;
	private float currentDmg;
	private float fuelDifference;
	private float dmgDifference;
	private float fuelPrice;
	private float dmgPrice;
	private bool pause;
	private Text textDmg;

	private Rigidbody2D taxi;

	// Use this for initialization
	void Start () {
		pause = false;
		fuelPrice = 1.2F;
		dmgPrice = 0.1F;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		canvasMothership = GameObject.FindGameObjectWithTag ("mothership") as Canvas;


		textDmg = GameObject.Find("playPause").GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelStats.IsMothershipActive) {
			canvasMothership.enabled = true;
		} else {
			canvasMothership.enabled = false;
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

	public void ClickPause(){
		if(!pause){
			Time.timeScale = 0.0F;
			textDmg.text =  "Play";
			pause = true;
		} else {
			Time.timeScale = 1.0F;
			textDmg.text =  "Pause";
			pause = false;
		}
	}

	public void ClickMenu(){
		taxi = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		
		//brauch man, damit das Taxi etwas versetzt wieder auftaucht, sonst lädt sich das lvl wieder
		float xVelo = taxi.velocity.x;
		float yVelo = taxi.velocity.y;
		
		if (xVelo > 0) {
			xVelo = 5;
		} else if (xVelo < 0) {
			xVelo = -5;
		} 
		if (yVelo > 0) {
			yVelo = 5;
		} else if (yVelo < 0) {
			yVelo = -5;
		} 
		
		levelStats.CurrentPosition = new Vector2 (taxi.transform.position.x - xVelo, taxi.transform.position.y - yVelo);

		levelStats.GameIsRunning = true;



		//HIER AUF 0 ÄNDERN!
		Application.LoadLevel (Application.levelCount - 1);
	}





}
