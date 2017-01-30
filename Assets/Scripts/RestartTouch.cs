﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTouch : MonoBehaviour {
	
	void OnMouseDown(){
		Scene actual = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (actual.name);
	}
}