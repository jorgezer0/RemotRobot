using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitterScript : MonoBehaviour {

	public enum actions {
		walk,
		jump
	}

	public actions Actions;

	public GameObject wave;
	public Color walkWave;
	public Color jumpWave;
	//GameObject newWave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Actions == actions.walk){
			if (Input.GetKeyDown ("z")) {
				//newWave = Instantiate (wave, transform.position, Quaternion.identity);
				wave.SetActive (true);
				wave.GetComponent<SpriteRenderer>().color = walkWave;
				wave.GetComponent<WaveScript> ().toWalk = true;
				wave.GetComponent<Animator> ().Play ("Wave", -1, 0f);
				StopCoroutine ("DestroyWave");
				StartCoroutine ("DestroyWave");
			}
		}
		if (Actions == actions.jump){
			if (Input.GetKeyDown ("x")) {
				//newWave = Instantiate (wave, transform.position, Quaternion.identity);
				wave.SetActive (true);
				wave.GetComponent<WaveScript>().toJump = true;
				wave.GetComponent<SpriteRenderer>().color = jumpWave;
				wave.GetComponent<Animator> ().Play ("Wave", -1, 0f);
				StopCoroutine ("DestroyWave");
				StartCoroutine ("DestroyWave");
			}
		}

	}

	IEnumerator DestroyWave(){
		yield return new WaitForSeconds (5);
		wave.SetActive (false);
	}
}
