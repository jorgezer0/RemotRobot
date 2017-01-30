using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour {

	public enum actions {
		walk,
		jump
	}

	public actions Actions;

	public GameObject[] emitters;

	void Start () {
		emitters = GameObject.FindGameObjectsWithTag ("Emitter");
	}

	void OnMouseDown(){
		if (Actions == actions.walk) {
			Debug.Log ("TOUCHw!!!");
			for (int i = 0; i <= (emitters.Length - 1); i++) {
				emitters [i].GetComponent<WaveEmitter> ().EmitWalk ();
			}
		} else if (Actions == actions.jump) {
			Debug.Log ("TOUCHj!!!");
			for (int i = 0; i <= (emitters.Length - 1); i++) {
				emitters [i].GetComponent<WaveEmitter> ().EmitJump ();
			}
		}
	}
}
