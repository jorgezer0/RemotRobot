using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchManager : MonoBehaviour {

	bool statusChanged = true;

	void Update () {
		if (Input.touchCount > 0) {
			Ray wp = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;
			if (Physics.Raycast (wp, out hit)) {
				if ((!statusChanged) && (hit.transform.gameObject.tag == "LevelButton")) {
					SceneManager.LoadScene ("Level"+hit.transform.GetComponent<SelectLevel>().level);
					Debug.Log("Level"+hit.transform.GetComponent<SelectLevel>().level);
				}
				statusChanged = true;
			}
		}
		if (Input.touchCount == 0) {
			statusChanged = false;
		}	
	}
}
