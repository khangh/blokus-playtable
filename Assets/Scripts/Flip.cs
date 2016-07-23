using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TouchScript.Gestures;

public class Flip : MonoBehaviour {

	void OnEnable(){
		GetComponent<ReleaseGesture>().Released += ReleaseHandler;
	}

	void ReleaseHandler (object sender, System.EventArgs e)
	{
		Vector3 orgPos = transform.parent.position;
		Quaternion orgRot = transform.parent.rotation;
		transform.parent.parent.RotateAround (transform.parent.parent.position, Vector3.up, 180.0f);
		transform.parent.position = orgPos;
		transform.parent.rotation = orgRot;
	}

	void OnDisable(){
		GetComponent<ReleaseGesture> ().Released -= ReleaseHandler;
	}
}
