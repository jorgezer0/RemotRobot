using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour {

	public int batNbr;

	Renderer rend;
	Material mat;

	float emission;
	public Color baseC;
	Color finalC;

	bool colected = false;

	public Transform posBat1;
	public Transform posBat2;
	public Transform posBat3;
	Vector3 vel = Vector3.zero;
	public float smoothTime;
	public Vector3 finalRot;

	Scene actual;
	bool counted = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		mat = rend.material;
		actual = SceneManager.GetActiveScene ();
		//PlayerPrefs.SetInt (actual.name + "Bat", 0);

	}

	// Update is called once per frame
	void Update () {
		BlinkLight ();

		if (colected) {
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

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			colected = true;
			if ((PlayerPrefs.GetInt (actual.name + "Bat") < 3) && (!counted)) {
				PlayerPrefs.SetInt (actual.name + "Bat", ((PlayerPrefs.GetInt (actual.name + "Bat") + 1)));
				counted = true;
			}
		}
	}

	void BlinkLight(){
		emission = Mathf.PingPong ((Time.time*2), 2f);
		baseC.b = emission;
		finalC = baseC;
		mat.SetColor ("_EmissionColor", finalC);
	}
}
