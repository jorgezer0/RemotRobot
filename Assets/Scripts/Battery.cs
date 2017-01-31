using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour {

	public int batNbr; //Number of the battery in order on level (1 - 3);

	//Variables to get the Material in order to change the color of the element;
	Renderer rend;
	Material mat;
	float emission;
	public Color baseC;
	Color finalC;

	// Bool to check if this battery was colected or not;
	bool colected = false;

	// Variables to animate the iten when it gets collected;
	public Transform posBat1;
	public Transform posBat2;
	public Transform posBat3;
	Vector3 vel = Vector3.zero;
	public float smoothTime;
	public Vector3 finalRot;

	// Variables to count the number of batterys collecteds in the level
	Scene actual;
	bool counted = false;

	void Start () {
		rend = GetComponent<Renderer> ();
		mat = rend.material;
		actual = SceneManager.GetActiveScene ();
	}
		
	void Update () {
		BlinkLight (); //Call function to change the color;

		if (colected) { // Routine to animate the colected batery;
			if (batNbr == 1) {
				GetComponent<CapsuleCollider> ().enabled = false;
				transform.SetParent (Camera.main.transform);
				transform.position = Vector3.SmoothDamp (transform.position, posBat1.position, ref vel, smoothTime);
				GetComponent<Animation> ().Play ();
			} else if (batNbr == 2) {
				transform.SetParent (Camera.main.transform);
				transform.position = Vector3.SmoothDamp (transform.position, posBat2.position, ref vel, smoothTime);
				GetComponent<Animation> ().Play ();
			} else {
				transform.SetParent (Camera.main.transform);
				transform.position = Vector3.SmoothDamp (transform.position, posBat3.position, ref vel, smoothTime);
				GetComponent<Animation> ().Play ();
			}
		}


	}

	void OnTriggerEnter(Collider col){ // Check if the player touched the battery;
		if (col.gameObject.tag == "Player") {
			colected = true;
			if ((PlayerPrefs.GetInt (actual.name + "Bat") < 3) && (!counted)) {
				PlayerPrefs.SetInt (actual.name + "Bat", ((PlayerPrefs.GetInt (actual.name + "Bat") + 1)));
				counted = true;
			}
		}
	}
		
	void BlinkLight(){ // Routine to change the color;
		emission = Mathf.PingPong ((Time.time*2), 2f);
		baseC.b = emission;
		finalC = baseC;
		mat.SetColor ("_EmissionColor", finalC);
	}
}
