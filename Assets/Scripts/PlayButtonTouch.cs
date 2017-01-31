using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonTouch : MonoBehaviour {

	public string scene;

	void OnMouseDown(){ // Load the level select scene;
		SceneManager.LoadScene (scene);
	}
}
