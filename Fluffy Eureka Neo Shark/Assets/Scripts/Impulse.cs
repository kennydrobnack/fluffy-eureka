using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {

	public Vector2 impulse;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = impulse;
	}

}
