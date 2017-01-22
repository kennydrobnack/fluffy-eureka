using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {


	public void QuitGame(){
        SFXController.Instance.PlaySound(SoundEffect.Ding);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
}
