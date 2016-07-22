using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;

public class Tile : MonoBehaviour {

	public static GameObject lastTransform = null;

	public GameObject grid;
	// Declare a list to hold all the blocks of the tiles
	public List<GameObject> blocks = new List<GameObject> ();
	// Add the blocks to the list
	void Awake() {
		foreach (Transform child in transform) {
			blocks.Add (child.gameObject);
		}
	}
	// General functions for adding delegates
	void OnEnable() {
		GetComponent<PressGesture>().Pressed += PressHandler;
		GetComponent<TransformGesture> ().Transformed += TransformedHandler;
		GetComponent<ReleaseGesture>().Released += ReleaseHandler;
	}

	void ReleaseHandler (object sender, System.EventArgs e) {
		//Debug.LogError ("release parent entered");

		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.forward, out hit)) {
			//Debug.LogError ("gameobject hit: " + hit.transform.gameObject.name);
			transform.position = hit.transform.position + new Vector3 (0.0f, 0.0f, -3.0f);
		}
	}

	void OnDisable() {
		GetComponent<PressGesture>().Pressed -= PressHandler;
		GetComponent<TransformGesture> ().Transformed -= TransformedHandler;
		GetComponent<ReleaseGesture> ().Released -= ReleaseHandler;
	}
	// Called when object is pressed
	void PressHandler (object sender, System.EventArgs e) {
		GameObject obj = transform.FindChild ("Transform").gameObject;
		if (lastTransform != obj && lastTransform != null) {
			lastTransform.SetActive (false);
			obj.SetActive (true);
			lastTransform = obj;
		} else {
			obj.SetActive (true);
			lastTransform = obj;
		}
	}
	// Called when object is being transformed by the gesture
	public void TransformedHandler(object sender, System.EventArgs e) {
		//detectCell ();
	}

	public void OnTriggerEnter(Collider other) {
		/*Debug.Log ("Hit");
		if (other.tag.Equals ("Cell")) {
			Debug.Log ("Hit2");
			transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, other.transform.position.z - 2);
		}*/
	}

	// Uses Raycast to identify which blocks are being hovered over on the grid
	public void detectCell(GameObject block) {
		var down = new Vector3 (0, 0, 1);

		RaycastHit hit;

		if (Physics.Raycast (block.transform.position, down, out hit, 20.0f)) {
			Cell cell = hit.collider.gameObject.GetComponent<Cell> ();
			if (cell != null) {
				//cell.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				//Debug.LogError ("(" + cell.column + ", " + cell.row + ")");
			}
		}
	}
	// Detect the cells on the grid
	public void detectCell() {
		foreach (GameObject block in blocks) {
			detectCell (block);
		}
	}
}
