using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour {

	public int toLevel; // Level that will be loaded;

	// Variables to get the components to change de color of the goal;
	public GameObject light1;
	public GameObject light2;
	Renderer light1Color;
	Renderer light2Color;

	void Start () {
		light1Color = light1.GetComponent<Renderer> ();
		light2Color = light2.GetComponent<Renderer> ();
		light1Color.material.color = Color.red;
		light2Color.material.color = Color.red;
	}

	void OnCollisionEnter(Collision col){ // Check the collision with the player with a small offset for visual porpouse;
		if ((col.gameObject.tag == "Player") && (col.transform.position.x > (transform.position.x - 0.8f))) {
			col.gameObject.GetComponent<PlayerMovement> ().remoteFWalk = false;
			light1Color.material.color = Color.green;
			light2Color.material.color = Color.green;
			StartCoroutine ("WaitToWarp");
		}
	}

	IEnumerator WaitToWarp(){ // Wait 1 second to load the next level;
		yield return new WaitForSeconds (1);
		if (toLevel > 0) {
			SceneManager.LoadScene ("Level" + toLevel);
		} else if (toLevel == 0) {	// If the next level is set do 0, load the level selec scene;
			SceneManager.LoadScene ("LevelSelect");
		}
	}
}
