using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {


	public void QuitGame(){
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif
		Application.Quit();
#endif
	}
}
