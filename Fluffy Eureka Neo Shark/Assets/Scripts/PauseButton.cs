using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

	public void Pause(){
		SetTimeScale (0f); 
	}
	public void UnPause(){
		SetTimeScale (1f);
	}

	public void SetTimeScale(float scale) {
		Time.timeScale = scale;
	}
}
