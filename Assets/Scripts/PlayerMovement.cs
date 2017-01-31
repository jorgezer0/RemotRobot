using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	// Variables to player movement;
	Rigidbody rigid;
	public float speed;
	public float jumpForce;
	bool isGrounded;
	public LayerMask ground;
	bool isMirror = false;
	float vSpeed;
	Animator anim;

	// Variables to check collisions;
	public Transform frontCheck;
	public Vector3 frontCheckBox;
	Collider[] frontCol;
	public Transform groundCheck;
	Collider[] groundCol;

	// Variables to remote commands;
	public bool remoteFWalk = false;
	bool isWalking = false;
	public float walkTime;
	public bool remoteJump = false;

	// Get RigidBody and Animator for manipulations;
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (remoteFWalk) { // Check if commando to walk was received;
			Walk (1);
			if (!isWalking) {
				isWalking = true;
				StartCoroutine ("RemoteWalkStop"); // Coroutine to count the time to stop walking
			}
		}
		if (remoteJump) { // Check if commando to jump was received;
			Jump ();
		}

		ManualControl (); // Routine to walk and jump manualy for tests pourpouse;

		if ((!remoteFWalk) && (Input.GetAxis ("Horizontal") == 0)) {
			anim.SetBool ("running", false);
		}

		// Vertical speed check to jump animation;
		vSpeed = GetComponent<Rigidbody> ().velocity.y;
		anim.SetFloat ("vSpeed", vSpeed);

		// Check collisions
		groundCol = Physics.OverlapSphere (groundCheck.position, 0.1f);
		if ((groundCol.Length > 0) && (groundCol [groundCol.Length-1].tag == "Ground")) {
			isGrounded = true;
			anim.SetBool ("isGround", isGrounded);
			remoteJump = false;
		} else if (groundCol.Length == 0) {
			isGrounded = false;
			anim.SetBool ("isGround", isGrounded);
		}

		frontCol = Physics.OverlapBox (frontCheck.position, frontCheckBox);
		if ((frontCol.Length > 0) && (frontCol[frontCol.Length-1].tag == "Ground")) {
			anim.SetBool ("running", false);
			remoteFWalk = false;
		}
			
	}

	void Walk(int dir){ // Walk function
		rigid.velocity = new Vector2 ((speed*dir), rigid.velocity.y);
		anim.SetBool ("running", true);
		if ((dir < 0) && (!isMirror)) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			isMirror = true;
		} else if ((dir > 0) && (isMirror)) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			isMirror = false;
		}
	}

	void Jump(){ // Jump function
		if (isGrounded) {
			GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpForce);
		}
	}
		
	IEnumerator RemoteWalkStop(){ // Coroutine to stop walking in a certain time;
		yield return new WaitForSeconds (walkTime);
		isWalking = false;
		Debug.Log ("Stop Walk.");
		anim.SetBool ("running", false);
		remoteFWalk = false;
	}
		
	void ManualControl(){ // Routine to walk and jump manualy for tests pourpouse;
		if (Input.GetAxis ("Horizontal") > 0) {
			Walk (1);
			anim.SetBool ("running", true);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			Walk (-1);
			anim.SetBool ("running", true);
		}

		if (Input.GetKeyDown("space")){
			Jump();
		}

		// Restart level manualy;
		if (Input.GetKeyDown("r")){
			Scene actual = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (actual.name);
		}
	}

}
