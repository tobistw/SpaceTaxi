using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public class GUIGameOver : MonoBehaviour {

	private LevelStats levelStats;
	private Text gameOverText;
	private Text gameOverTextShadow;
	private int menuLevelIndex = 0;
	private int startLevelIndex = 1;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameOverText = GameObject.Find("Highscore").GetComponent <Text> ();
		gameOverTextShadow = GameObject.Find("Highscore").GetComponent <Text> ();
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (TaxiManager.instance.isGameOver) {
			setHighscore();
			if(TaxiManager.instance.newHighscore){
				gameOverText.text = "Neuer Highscore!!! \n" +  TaxiManager.instance.highscore + " $";
				gameOverTextShadow.text = "Neuer Highscore!!! \n" +  TaxiManager.instance.highscore + " $";
			} else {
				gameOverText.text = "Kein neuer Highscore. \n" +  "alter Highscore: " + TaxiManager.instance.highscore + " $";
				gameOverTextShadow.text = "Kein neuer Highscore. \n" +  "alter Highscore: " +  TaxiManager.instance.highscore + " $";
			}

		}
	}


	void setHighscore(){
		TaxiManager.instance.newHighscore = false;
		if (levelStats.Highscore == null || levelStats.Highscore < TaxiManager.instance.budget) {
			levelStats.Highscore = TaxiManager.instance.budget;
			TaxiManager.instance.newHighscore = true;
		}
		TaxiManager.instance.highscore = levelStats.Highscore;
	}

	public void ClickMenu(){
		levelStats.GameIsRunning = false;
		Application.LoadLevel (menuLevelIndex);
	}

	public void ClickNewGame(){
		//Playerprefs bis auf highscore zurücksetzten 
		
		levelStats.GameIsRunning = true;
		/*Application.Quit ();
		Destroy (TaxiManager.instance.gameObject);
		Destroy (OrbManager.instance.gameObject);
		Destroy (PassengerManager.instance.gameObject);*/
		Application.LoadLevel (startLevelIndex);


	} 
}
