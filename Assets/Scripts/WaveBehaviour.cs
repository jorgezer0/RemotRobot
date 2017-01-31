using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {

	// Variables to set the wave behaviour;
	public bool toWalk = false;
	public bool toJump = false;

	// Check the collision with the player adn which behaviour will be set to player;
	void OnTriggerEnter(Collider col){
			if ((col.gameObject.tag == "Player") && (toWalk)) {
				col.gameObject.GetComponent<PlayerMovement> ().remoteFWalk = true;
			}

			if ((col.gameObject.tag == "Player") && (toJump)) {
				col.gameObject.GetComponent<PlayerMovement> ().remoteJump = true;
			}
	}
}
