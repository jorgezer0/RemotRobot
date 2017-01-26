using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

	public Transform maxH;
	public Transform minH;
	Vector3 vel = Vector3.zero;
	public float smoothTime;
	bool isUp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
