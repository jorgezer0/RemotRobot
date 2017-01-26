using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

	public bool toWalk = false;

	public bool toJump = false;

	void OnTriggerEnter(Collider col){
		if ((col.gameObject.tag == "Player") && (toWalk)) {
			Debug.Log ("Wave!");
			//PlayerPrefs.SetInt ("walk", 1);
			col.gameObject.GetComponent<PlayerMovement>().remoteFWalk = true;
		}

		if ((col.gameObject.tag == "Player") && (toJump)) {
			Debug.Log ("JUMP!");
			//PlayerPrefs.SetInt ("walk", 1);
			col.gameObject.GetComponent<PlayerMovement>().remoteJump = true;
		}
	}
}
