using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Seagull : MonoBehaviour {


	//If we collide with the player, game over
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player")) {
			SceneManager.LoadScene (0);
		}
	}

}
