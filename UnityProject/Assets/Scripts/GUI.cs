using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour {

	public float fuelGrafikFull;
	public float dmgGrafikFull;
	private LevelStats levelStats;
	private float currentDmgProzent;
	private float currentFuel;

	private GameObject fuelFuellung;
	private GameObject dmgFuellung;
	private Text textBudget;
	private Text textBudgetShadow;
	private Text textFuel;
	private Text textFuelShadow;
	private Text textDmg;
	private Text textDmgShadow;


	// Use this for initialization
	void Start () {
		dmgGrafikFull = 4.32F;
		fuelGrafikFull = 4.32F;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}

		fuelFuellung = GameObject.Find ("fuel_fuellung");
		dmgFuellung = GameObject.Find ("dmg_fuellung");

		textBudget = GameObject.Find("budget").GetComponent <Text> ();
		textBudgetShadow = GameObject.Find("budget_shadow").GetComponent <Text> ();
		textFuel = GameObject.Find("fuel").GetComponent <Text> ();
		textFuelShadow = GameObject.Find("fuel_shadow").GetComponent <Text> ();
		textDmg = GameObject.Find("dmg").GetComponent <Text> ();
		textDmgShadow = GameObject.Find("dmg_shadow").GetComponent <Text> ();

	}
	//text = GetComponent <Text> ();
	// Update is called once per frame
	void Update () {

		//Damage
		currentDmgProzent = Mathf.Round (PlayerPrefs.GetFloat ("Damage") / (levelStats.Stability / 100));
			//text
		textDmg.text =  (currentDmgProzent) + " %";
		textDmgShadow.text = (currentDmgProzent) + " %";
			//grafik
		dmgFuellung.transform.localScale = new Vector3(currentDmgProzent * (dmgGrafikFull / 100), dmgFuellung.transform.localScale.y);


		//Tank
		currentFuel = Mathf.Round(PlayerPrefs.GetFloat ("Fuel"));
			//text
		textFuel.text = (currentFuel) + " / " +  levelStats.FuelVolume +  " l";
		textFuelShadow.text = (currentFuel) + " / " +  levelStats.FuelVolume +  " l";
			//grafik
		fuelFuellung.transform.localScale = new Vector3(fuelGrafikFull/levelStats.FuelVolume * currentFuel, fuelFuellung.transform.localScale.y);

		//Budget
		textBudget.text = PlayerPrefs.GetInt ("Budget") + " / " + PlayerPrefs.GetInt ("Achievement") + " $";
		textBudgetShadow.text = PlayerPrefs.GetInt ("Budget") + " / " + PlayerPrefs.GetInt ("Achievement") + " $";


	}

}
