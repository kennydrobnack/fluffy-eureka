using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Seagull : MonoBehaviour {

	//Adds extra space around the camera bounds before the object is destroyed
	public float margin = 2f;


	//If we collide with the player, game over
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("player")) {
			SceneManager.LoadScene (0);
		}
	}

	//Orient the sprite based on X velocity
	void Start() {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (rb.velocity.x < 0)
			sprite.flipX = true;
	}

	//Check to see if we're outside of the camera + margin
	void Update() {
		Camera camera = Camera.main;
		float width = camera.orthographicSize+margin;
		float height = camera.aspect * width+margin;
		Rect bounds = new Rect (camera.transform.position.x-.5f*width, camera.transform.position.y-.5f*height, width, height);
		if (!bounds.Contains (transform.position)) {
			Destroy (gameObject);
		}
	}
}
