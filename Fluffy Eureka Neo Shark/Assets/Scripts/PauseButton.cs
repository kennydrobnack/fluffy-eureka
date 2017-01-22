using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

	public void Pause(){
        SFXController.Instance.PlaySound(SoundEffect.PawsButton);
        SFXController.Instance.PauseBGMusic();
        SetTimeScale (0f); 
	}
	public void UnPause(){
        SFXController.Instance.UnPauseBGMusic();
        SetTimeScale (1f);
	}

	public void SetTimeScale(float scale) {
        
		Time.timeScale = scale;
	}
}
