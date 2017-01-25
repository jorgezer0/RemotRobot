using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform player;
	Vector3 playerPosition;
	public Vector3 followPos;
	public float smoothTime;
	Vector3 vel = Vector3.zero;
	bool isFlip = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = player.TransformPoint (followPos);
		transform.position = Vector3.SmoothDamp (transform.position, playerPosition, ref vel, smoothTime);
	}

	public void FlipCamera(int dir){
		if ((dir < 0) && (!isFlip)) {
			playerPosition.x = playerPosition.x * -1;
			isFlip = true;
		} else if ((dir > 0) && (isFlip)) {
			playerPosition.x = playerPosition.x * -1;
			isFlip = false;
		}

	}
}
