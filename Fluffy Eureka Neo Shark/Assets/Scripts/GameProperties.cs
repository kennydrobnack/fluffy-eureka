using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProperties : MonoBehaviour {

    [SerializeField]
    private float _gameSpeed;
    [SerializeField]
    private Text scoreText, hiscoreText;

    private int hiScore, score;

    public float GameSpeed {
        get
        {
            return _gameSpeed;
        }
        set
        {
            _gameSpeed = value;
        }
    }

    public static GameProperties instance;
	// Use this for initialization
	void Awake () {
	    if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        DisplayHiScore();
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        SFXController.Instance.PlaySound(SoundEffect.Can);
        SetHiScore();
    }

    private void SetHiScore()
    {
        if (score > hiScore)
        {
            PlayerPrefs.SetInt("hiscore", score);
            DisplayHiScore();
        }
    }

    private void DisplayHiScore ()
    {
        hiScore = PlayerPrefs.GetInt("hiscore");
        hiscoreText.text = hiScore.ToString();
    }
}
