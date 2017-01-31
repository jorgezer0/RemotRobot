using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour {

	//Actions available to the Emitters
	public enum actions {
		walk,
		jump
	}

	public actions Actions; // Dropdown menu to select which wave will be sent

	public GameObject[] emitters;

	void Start () {
		emitters = GameObject.FindGameObjectsWithTag ("Emitter"); //Getting all emitters in the level.
	}

	void OnMouseDown(){
		if (Actions == actions.walk) { //If Actions is set to "Walk"
			for (int i = 0; i <= (emitters.Length - 1); i++) { //All Emitters send "Walk" waves
				emitters [i].GetComponent<WaveEmitter> ().EmitWalk ();
			}
		} else if (Actions == actions.jump) { //If Actions is set to "Jump"
			for (int i = 0; i <= (emitters.Length - 1); i++) { //All Emitters send "Jump" waves
				emitters [i].GetComponent<WaveEmitter> ().EmitJump ();
			}
		}
	}
}
