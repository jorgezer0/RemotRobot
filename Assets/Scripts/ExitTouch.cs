using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTouch : MonoBehaviour {

	bool statusChanged = false;

	void Update () {
		if (Input.touchCount > 0) {
			Ray wp = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;
			if (Physics.Raycast (wp, out hit)) {
				if ((!statusChanged) && (hit.transform.tag == "ExitButton")) {
					SceneManager.LoadScene ("Title");
				}
				statusChanged = true;
			}
		}
		if (Input.touchCount == 0) {
			statusChanged = false;
		}		
	}
}
