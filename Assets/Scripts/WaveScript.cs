using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Wave!");
			//PlayerPrefs.SetInt ("walk", 1);
			GameObject.Find("Player").GetComponent<PlayerMovement>().remoteFWalk = true;
		}
	}
}
