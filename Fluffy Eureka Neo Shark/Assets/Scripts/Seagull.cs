using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Seagull : MonoBehaviour {

	public float timeToLoad = 2f;
	//If we collide with the player, game over
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Player")) {
			DisablePlayer (other);
			Destroy (this);
		}
	}

	void DisablePlayer(Collider2D player) {
		PlayerController con = player.GetComponent<PlayerController> ();
		Destroy (con);
		PolygonCollider2D col = player.GetComponent<PolygonCollider2D> ();
		Destroy (col);
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		Vector3 vel = rb.velocity;
		vel.x = 0f;
		vel.y = 10f;
		rb.velocity = vel;
		Invoke ("LoadLevel", 0f);
	}
	void LoadLevel(){
		if(Monetizr.Instance != null) 
			Monetizr.Instance.ShowProductWithID ("9920046026");

		SceneManager.LoadScene (0);
	}


}
