using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour {

	//Actions available to the Emitters
	public enum actions {
		walk,
		jump
	}

	public actions Actions; // Dropdown menu to select which wave will be sent

	//Variables to get the Material in order to change the color of the waves;
	public GameObject wLight;
	Renderer lightColor;
	SpriteRenderer waveColor;
	WaveBehaviour waveScript;
	Animator waveAnim;
	public GameObject wave;
	public Color walkWave;
	public Color jumpWave;

	// Get the component to manipulate colors;
	void Start(){
		waveColor = wave.GetComponent<SpriteRenderer> ();
		waveScript = wave.GetComponent<WaveBehaviour> ();
		waveAnim = wave.GetComponent<Animator> ();
		lightColor = wLight.GetComponent<Renderer> ();
		if (Actions == actions.walk) {
			waveColor.color = walkWave;
			lightColor.material.color = walkWave;
		} else if (Actions == actions.jump) {
			waveColor.color = jumpWave;
			lightColor.material.color = jumpWave;
		}

	}

	void Update () {
		ManualEmission (); // Function to activate emitters manualy to play in editor;
	}
		
	public void EmitWalk(){ // Function to emit walk waves;
		if (Actions == actions.walk) {
			wave.SetActive (true);
			waveScript.toWalk = true;
			waveAnim.Play ("Wave", -1, 0f);
			StopCoroutine ("DestroyWave");
			StartCoroutine ("DestroyWave");
		}
	}

	public void EmitJump(){ // Function to emit jump waves;
		if (Actions == actions.jump) {
			wave.SetActive (true);
			waveScript.toJump = true;
			waveAnim.Play ("Wave", -1, 0f);
			StopCoroutine ("DestroyWave");
			StartCoroutine ("DestroyWave");
		}
	}

	IEnumerator DestroyWave(){ // Coroutine to end emission;
		yield return new WaitForSeconds (1.6f);
		wave.SetActive (false);
	}

	void ManualEmission(){ // Function to activate emitters manualy to play in editor;
		if (Actions == actions.walk){
			if (Input.GetKeyDown ("z")) {
				EmitWalk();
			}
		}
		if (Actions == actions.jump){
			if (Input.GetKeyDown ("x")) {
				EmitJump();
			}
		}
	}
}
