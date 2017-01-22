using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {


	public void LoadLevel(int index) {
        SFXController.Instance.PlaySound(SoundEffect.Ding);
        SceneManager.LoadScene (index);
	}

    
}
