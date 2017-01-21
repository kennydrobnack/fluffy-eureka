using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Seagull : MonoBehaviour {

	//Adds extra space around the camera bounds before the object is destroyed
	public float margin = 2f;

	private Rigidbody2D rb;
	private SpriteRenderer sprite;


	//If we collide with the player, game over
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player")) {
			SceneManager.LoadScene (0);
		}
	}

	//Orient the sprite based on X velocity
	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		if (rb.velocity.x < 0)
			sprite.flipX = true;
	}
	void Update(){
		FlipSprite ();
	}

	private void FlipSprite() {
		if (rb.velocity.x < 0)
			sprite.flipX = true;
	}

}
