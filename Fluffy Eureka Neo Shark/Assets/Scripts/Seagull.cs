using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Seagull : MonoBehaviour {


	//If we collide with the player, game over
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Player")) {
			Monetizr.Instance.ShowProductWithID ("9920046026");
			SceneManager.LoadScene (0);
		}
	}


}
