using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;

public class Tile : MonoBehaviour {

	public static GameObject lastTransformRed = null;
	public static GameObject lastTransformBlue = null;
	public static GameObject lastTransformGreen = null;
	public static GameObject lastTransformYellow = null;

	public GameObject grid;
	// Declare a list to hold all the blocks of the tiles
	public List<GameObject> blocks = new List<GameObject> ();

	public bool canRotate = true;

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
		if (canRotate) {
			GameObject obj = transform.FindChild ("Transform").gameObject;
			//Find this tile's team;
			TeamColor myColor = transform.parent.GetComponent<color> ().myColor;
			// Change correct transform depending on team
			if (myColor == TeamColor.yellow) {
				if (lastTransformYellow != obj && lastTransformYellow != null) {
					lastTransformYellow.SetActive (false);
					obj.SetActive (true);
					lastTransformYellow = obj;
				} else {
					obj.SetActive (true);
					lastTransformYellow = obj;
				}
			} else if (myColor == TeamColor.red) {
				if (lastTransformRed != obj && lastTransformRed != null) {
					lastTransformRed.SetActive (false);
					obj.SetActive (true);
					lastTransformRed = obj;
				} else {
					obj.SetActive (true);
					lastTransformRed = obj;
				}
			} else if (myColor == TeamColor.green) {
				if (lastTransformGreen != obj && lastTransformGreen != null) {
					lastTransformGreen.SetActive (false);
					obj.SetActive (true);
					lastTransformGreen = obj;
				} else {
					obj.SetActive (true);
					lastTransformGreen = obj;
				}
			} else if (myColor == TeamColor.blue) {
				if (lastTransformBlue != obj && lastTransformBlue != null) {
					lastTransformBlue.SetActive (false);
					obj.SetActive (true);
					lastTransformBlue = obj;
				} else {
					obj.SetActive (true);
					lastTransformBlue = obj;
				}
			}
		} else {
			TeamColor myColor = transform.parent.GetComponent<color> ().myColor;
			// Change correct transform depending on team
			if (myColor == TeamColor.yellow) {
				if (lastTransformYellow != null) {
					lastTransformYellow.SetActive (false);
					lastTransformYellow = null;
				}
			} else if (myColor == TeamColor.red) {
				if (lastTransformRed != null) {
					lastTransformRed.SetActive (false);
					lastTransformRed = null;
				}
			} else if (myColor == TeamColor.green) {
				if (lastTransformGreen != null) {
					lastTransformGreen.SetActive (false);
					lastTransformGreen = null;
				}
			} else if (myColor == TeamColor.blue) {
				if (lastTransformBlue != null) {
					lastTransformBlue.SetActive (false);
					lastTransformBlue = null;
				}
			}
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
