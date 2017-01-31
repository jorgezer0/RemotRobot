using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {


	public Transform maxH; // Max position of the elevator;
	public Transform minH; // Min position of the elevator;
	Vector3 vel = Vector3.zero;
	public float smoothTime;
	public bool isUp = false; // Check if the elevator reach the max position;

	void FixedUpdate () {
		if (!isUp) {
			transform.position = Vector3.SmoothDamp (transform.position, maxH.position, ref vel, smoothTime);
			if (transform.position == maxH.position) {
				isUp = true;
			}
		} else if (isUp){
			transform.position = Vector3.SmoothDamp (transform.position, minH.position, ref vel, smoothTime);
			if (transform.position == minH.position) {
				isUp = false;
			}
		}
	}
}
