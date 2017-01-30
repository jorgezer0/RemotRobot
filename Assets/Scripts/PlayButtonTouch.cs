using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonTouch : MonoBehaviour {

	public string scene;
	bool statusChanged = false;

	void OnMouseDown(){
		SceneManager.LoadScene ("LevelSelect");
	}
}
