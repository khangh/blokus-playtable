﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TouchScript.Gestures;

public class Rotate : MonoBehaviour {

	public GameObject pivot = null;

	void OnEnable(){
		GetComponent<ReleaseGesture>().Released += ReleaseHandler;
	}

	void ReleaseHandler (object sender, System.EventArgs e)
	{
		Vector3 orgPos = transform.parent.position;
		Quaternion orgRot = transform.parent.rotation;
		if (pivot == null) {
			transform.parent.parent.RotateAround (transform.parent.parent.position, Vector3.forward, 90.0f);
		} else {
			transform.parent.parent.RotateAround (pivot.transform.position, Vector3.forward, 90.0f);
		}
		transform.parent.position = orgPos;
		transform.parent.rotation = orgRot;
	}

	void OnDisable(){
		GetComponent<ReleaseGesture> ().Released -= ReleaseHandler;
	}
}
