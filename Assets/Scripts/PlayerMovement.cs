using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigid;
	public float speed;
	public float jumpForce;
	bool isGrounded;
	public LayerMask ground;
	bool isMirror = false;
	float vSpeed;
	Animator anim;

	public Transform frontCheck;
	public Vector3 frontCheckBox;
	Collider[] frontCol;
	public Transform groundCheck;
	Collider[] groundCol;

	public bool remoteFWalk = false;
	bool isWalking = false;
	public float walkTime;
	public bool remoteJump = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (remoteFWalk) {
			Debug.Log ("Start Walk.");
			Walk (1);
			if (!isWalking) {
				isWalking = true;
				StartCoroutine ("RemoteWalkStop");
			}
		}
		if (remoteJump) {
			Jump ();
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			Walk (1);
			anim.SetBool ("running", true);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			Walk (-1);
			anim.SetBool ("running", true);
		}
		if ((!remoteFWalk) && (Input.GetAxis ("Horizontal") == 0)) {
			anim.SetBool ("running", false);
		}
		vSpeed = GetComponent<Rigidbody> ().velocity.y;
		anim.SetFloat ("vSpeed", vSpeed);
		if (Input.GetKeyDown("space")){
			Jump();
		}

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

		if (Input.GetKeyDown("r")){
			Scene actual = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (actual.name);
		}
	}

	void Walk(int dir){
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

	void Jump(){
		if (isGrounded) {
			GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpForce);
		}
	}
		
	IEnumerator RemoteWalkStop(){
		yield return new WaitForSeconds (walkTime);
		isWalking = false;
		Debug.Log ("Stop Walk.");
		anim.SetBool ("running", false);
		remoteFWalk = false;
	}

	void OnTriggerEnter(Collider col){
//		if (col.gameObject.tag == "Wave") {
//			if ((!remoteFWalk) || (!remoteJump)) {
//				col.gameObject.GetComponent<WaveBehaviour> ().isSet = false;
//			}
//		}
	}

}
