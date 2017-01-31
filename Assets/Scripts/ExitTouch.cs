using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTouch : MonoBehaviour {

	// Bool to check if this Exit Button is intended to exit the level or the game;
	public bool exitGame = false;

	void OnMouseDown(){
		if (!exitGame) {
			SceneManager.LoadScene ("Title");
		} else if (exitGame) {
			Application.Quit ();
		}
	}
}
