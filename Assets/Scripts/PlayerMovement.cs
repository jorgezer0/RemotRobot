using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public GameObject feet;
	bool isGrounded;
	public LayerMask ground;
	bool isMirror = false;
	float vSpeed;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			Walk (1);
			anim.SetBool ("running", true);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			Walk (-1);
			anim.SetBool ("running", true);
		}
		if (Input.GetAxis ("Horizontal") == 0) {
			anim.SetBool ("running", false);
		}
		vSpeed = GetComponent<Rigidbody> ().velocity.y;
		anim.SetFloat ("vSpeed", vSpeed);
		if (Input.GetKeyDown("space")){
			Jump();
		}
		
	}

	void Walk(int dir){
		transform.position = new Vector2 ((transform.position.x + ((speed*dir) * Time.deltaTime)), transform.position.y);
		if ((dir < 0) && (!isMirror)) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			isMirror = true;
		} else if ((dir > 0) && (isMirror)) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			isMirror = false;
		}
	}

	void Jump(){
		GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpForce);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {	
			isGrounded = true;
			anim.SetBool ("isGround", isGrounded);
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
			anim.SetBool ("isGround", isGrounded);
		}
	}

}
