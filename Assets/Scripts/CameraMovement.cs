﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Variables to set camera follow behaviour;
	public Transform player;
	Vector3 playerPosition;
	public Vector3 followPos;
	public float smoothTime;
	Vector3 vel = Vector3.zero;

	void Update () {
		playerPosition = player.TransformPoint (followPos);
		transform.position = Vector3.SmoothDamp (transform.position, playerPosition, ref vel, smoothTime);
	}
}
