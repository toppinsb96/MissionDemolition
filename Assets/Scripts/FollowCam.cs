﻿using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	static public FollowCam S; // a FollowCam Singleton
	public float easing = 0.05f;
	public Vector2 minXY;
	public bool _____________________________________________;
	public GameObject poi; 
	public float camZ; 

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	void Start () {

	}
	void FixedUpdate () {
		Vector3 destination;
		if (poi == null) {
			destination = Vector3.zero;
		} else {
			destination = poi.transform.position;
			if (poi.tag == "Projectile") {
				if (poi.GetComponent<Rigidbody>().IsSleeping()) {
					poi = null;
					Destroy(poi);
					return;
				}
			}
		}
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max(minXY.y, destination.y);
		destination = Vector3.Lerp(transform.position, destination, easing);
		destination.z = camZ;
		this.transform.position = destination;
		this.GetComponent<Camera>().orthographicSize = destination.y + 10;
	}
}
