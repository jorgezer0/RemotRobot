using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	public int level;
	public TextMesh number;
	public TextMesh btQty;

	void Start(){ // Set the text on button to the level it calls;
		number.text = level.ToString ();
		btQty.text = ("x " + PlayerPrefs.GetInt ("Level" + level + "Bat").ToString());
	}

	void OnMouseDown(){ // Go to level;
		SceneManager.LoadScene ("Level"+level);
	}
}
