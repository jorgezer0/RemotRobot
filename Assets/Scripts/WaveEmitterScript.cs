using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitterScript : MonoBehaviour {

	public GameObject wave;
	GameObject newWave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("z")) {
			newWave = Instantiate (wave, transform.position, Quaternion.identity);
			newWave.GetComponent<Animator> ().Play("Wave", -1, 0f);
			StartCoroutine ("DestroyWave");

		}
	}

	IEnumerator DestroyWave(){
		yield return new WaitForSeconds (5);
		Destroy (newWave);
	}
}
