using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Cell : MonoBehaviour {
	public int column; // x
	public int row; // y

	public static Color defaultColor = Color.white;

	void Awake() {
		GetComponent<Renderer> ().material.color = defaultColor;
	}

	void OnEnable() {
		GetComponent<LongPressGesture>().LongPressed += LongPressHander;
	}

	void OnDisable() {
		GetComponent<LongPressGesture> ().LongPressed -= LongPressHander;
	}

	void LongPressHander (object sender, System.EventArgs e) {
		Debug.LogError(column + ", " + row);
	}

}
