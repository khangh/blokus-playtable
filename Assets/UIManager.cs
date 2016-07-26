using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void OnClickReset(){
		SceneManager.LoadScene (0);
	}

	public void OnClickExit(){
		Application.Quit ();
	}

	public void EnableIsDisplayed(Animator anim){
		anim.SetBool ("IsDisplayed", true);
	}

	public void DisableIsDisplayed(Animator anim){
		anim.SetBool ("IsDisplayed", false);
	}
}
