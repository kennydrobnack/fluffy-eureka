using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestJump : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GameObject.FindGameObjectWithTag("Cat").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			anim.SetBool ("isJumping", true);
		} else {
			anim.SetBool ("isJumping", false);
		}
	}
}
