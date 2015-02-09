using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	 
	public void ClickNewGame(){
		Application.LoadLevel (0);
		//Playerprefs bis auf highscore zurücksetzten 

	}

	public void ClickQuit(){

		Application.Quit ();
	}

	//Klick auf fortsetzten -> Position Tankschiff

}
