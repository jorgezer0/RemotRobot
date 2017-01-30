using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTouch : MonoBehaviour {

	public bool exitGame = false;

	void OnMouseDown(){
		if (!exitGame) {
			SceneManager.LoadScene ("Title");
		} else if (exitGame) {
			Application.Quit ();
		}
	}
}
