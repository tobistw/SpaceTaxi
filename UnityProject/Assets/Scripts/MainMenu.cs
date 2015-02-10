using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Canvas optionenCanvas;
	public Canvas rechteCanvas;
	public Canvas mainMenuCanvas;
	private LevelStats levelStats;
	public Button fortsetzten;

	private int startLevelIndex = 1;
	private GameObject gameControllerObject;

	void Start(){
		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			
			levelStats = gameControllerObject.GetComponent<LevelStats> ();
		} else {
			Debug.Log("Cant find Game Controller Object");
		}
		optionenCanvas.enabled = false;
		rechteCanvas.enabled = false;

	}

	void Update(){
		//Debug.Log("läuft ein Spiel?: " +  levelStats.GameIsRunning);
		if (levelStats.GameIsRunning) {

			fortsetzten.interactable = true;
		} else {
			fortsetzten.interactable = false;
		}
	}

	public void ClickNewGame(){
		//Playerprefs bis auf highscore zurücksetzten 
		TaxiManager.instance.resetTaxiManager ();
		PassengerManager.instance.clearGuestList ();
		OrbManager.instance.resetOrbManager ();
		TaxiManager.instance.toggleNewGameStarted ();

		Application.LoadLevel (startLevelIndex);

		levelStats.GameIsRunning = true;
		Debug.Log("läuft ein Spiel?: " +  levelStats.GameIsRunning);
	}

	public void ClickFortsetzten(){
		Application.LoadLevel (startLevelIndex);		
	}



	public void ClickQuit(){
		levelStats.GameIsRunning = false;
		Application.Quit ();
	}

	//Klick auf fortsetzten -> Position Tankschiff

	public void ClickOptionen(){
		optionenCanvas.enabled = true;
		mainMenuCanvas.enabled = false;
	}

	public void ClickRechte(){
		rechteCanvas.enabled = true;
		mainMenuCanvas.enabled = false;
	}

	public void ClickZurueck_1(){
		mainMenuCanvas.enabled = true;
		optionenCanvas.enabled = false;
		rechteCanvas.enabled = false;
	}





}
