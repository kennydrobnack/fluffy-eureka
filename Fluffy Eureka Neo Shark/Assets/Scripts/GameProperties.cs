using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour {

    [SerializeField]
    private float _gameSpeed;

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
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
