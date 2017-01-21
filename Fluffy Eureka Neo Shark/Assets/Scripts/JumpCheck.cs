using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour {

	Animator anim;

	void Start() {
		anim = GameObject.FindGameObjectWithTag("Cat").GetComponent<Animator> ();	
	}

	void OnCollisionEnter2D(Collision2D other) {
		anim.SetBool ("isJumping", false);
	}

	void OnCollisionExit2D(Collision2D other) {
		anim.SetBool ("isJumping", true);
	}
}
