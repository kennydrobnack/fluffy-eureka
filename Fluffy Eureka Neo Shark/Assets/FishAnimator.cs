using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class FishAnimator : MonoBehaviour {

	public float ratio;
	private Animator anim;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("xSpeed", Mathf.Abs (rb.velocity.x));
		anim.SetFloat ("ySpeed", Mathf.Abs (rb.velocity.y));
		ratio = Mathf.Abs (rb.velocity.x / rb.velocity.y);
		anim.SetFloat ("ratio", ratio);
	}
}
