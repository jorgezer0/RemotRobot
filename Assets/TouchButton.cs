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

	bool statusChanged = false;

	// Use this for initialization
	void Start () {
		emitters = GameObject.FindGameObjectsWithTag ("Emitter");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Ray wp = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;
			if (Physics.Raycast (wp, out hit)) {
				if ((!statusChanged) && (hit.transform.tag == "TouchWalk")) {
					Debug.Log ("TOUCHw!!!");
					for (int i = 0; i <= (emitters.Length - 1); i++) {
						emitters [i].GetComponent<WaveEmitter> ().EmitWalk ();
					}
				} else if ((!statusChanged) && (hit.transform.tag == "TouchJump")) {
					Debug.Log ("TOUCHj!!!");
					for (int i = 0; i <= (emitters.Length - 1); i++) {
						emitters [i].GetComponent<WaveEmitter> ().EmitJump ();
					}
				}
				statusChanged = true;
			}
		}
		if (Input.touchCount == 0) {
			statusChanged = false;
		}		
	}
}
