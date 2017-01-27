using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {

	public bool isSet = false;
	public bool toWalk = false;
	public bool toJump = false;

	void OnTriggerEnter(Collider col){
//		if (!isSet) {
			if ((col.gameObject.tag == "Player") && (toWalk)) {
				isSet = true;
				Debug.Log ("Wave!");
				//PlayerPrefs.SetInt ("walk", 1);
				col.gameObject.GetComponent<PlayerMovement> ().remoteFWalk = true;
			}

			if ((col.gameObject.tag == "Player") && (toJump)) {
				isSet = true;
				Debug.Log ("JUMP!");
				//PlayerPrefs.SetInt ("walk", 1);
				col.gameObject.GetComponent<PlayerMovement> ().remoteJump = true;
			}
//		}
	}
}
