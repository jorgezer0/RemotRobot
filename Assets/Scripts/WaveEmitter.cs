using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour {

	public enum actions {
		walk,
		jump
	}

	public actions Actions;

	public GameObject light;
	Renderer lightColor;

	SpriteRenderer waveColor;
	WaveBehaviour waveScript;
	Animator waveAnim;

	public GameObject wave;
	public Color walkWave;
	public Color jumpWave;

	void Start(){
		waveColor = wave.GetComponent<SpriteRenderer> ();
		waveScript = wave.GetComponent<WaveBehaviour> ();
		waveAnim = wave.GetComponent<Animator> ();
		lightColor = light.GetComponent<Renderer> ();
		if (Actions == actions.walk) {
			waveColor.color = walkWave;
			lightColor.material.color = walkWave;
		} else if (Actions == actions.jump) {
			waveColor.color = jumpWave;
			lightColor.material.color = jumpWave;
		}

	}

	void Update () {
		if (Actions == actions.walk){
			if (Input.GetKeyDown ("z")) {
				//newWave = Instantiate (wave, transform.position, Quaternion.identity);
				wave.SetActive (true);
				waveScript.toWalk = true;
				waveAnim.Play ("Wave", -1, 0f);
				StopCoroutine ("DestroyWave");
				StartCoroutine ("DestroyWave");
			}
		}
		if (Actions == actions.jump){
			if (Input.GetKeyDown ("x")) {
				//newWave = Instantiate (wave, transform.position, Quaternion.identity);
				wave.SetActive (true);
				waveScript.toJump = true;
				waveAnim.Play ("Wave", -1, 0f);
				StopCoroutine ("DestroyWave");
				StartCoroutine ("DestroyWave");
			}
		}

	}

	IEnumerator DestroyWave(){
		yield return new WaitForSeconds (1.6f);
		wave.SetActive (false);
	}
}
