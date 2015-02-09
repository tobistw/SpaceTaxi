using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Canvas optionenCanvas;
	public Canvas rechteCanvas;
	public Canvas mainMenuCanvas;
	private LevelStats levelStats;
	public Button fortsetzten;


	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
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

		levelStats.GameIsRunning = true;
		Debug.Log("läuft ein Spiel?: " +  levelStats.GameIsRunning);
		Application.LoadLevel (0);


	}

	public void ClickFortsetzten(){
		Application.LoadLevel (0);		
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
