using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour {

	public int toLevel;

	public GameObject light1;
	public GameObject light2;
	Renderer light1Color;
	Renderer light2Color;


	// Use this for initialization
	void Start () {
		light1Color = light1.GetComponent<Renderer> ();
		light2Color = light2.GetComponent<Renderer> ();
		light1Color.material.color = Color.red;
		light2Color.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if ((col.gameObject.tag == "Player") && (col.transform.position.x > (transform.position.x - 0.8f))) {
			col.gameObject.GetComponent<PlayerMovement> ().remoteFWalk = false;
			light1Color.material.color = Color.green;
			light2Color.material.color = Color.green;
			StartCoroutine ("WaitToWarp");
		}
	}

	IEnumerator WaitToWarp(){
		yield return new WaitForSeconds (1);
		if (toLevel > 0) {
			SceneManager.LoadScene ("Level" + toLevel);
		} else if (toLevel == 0) {
			SceneManager.LoadScene ("LevelSelect");
		}
	}
}
