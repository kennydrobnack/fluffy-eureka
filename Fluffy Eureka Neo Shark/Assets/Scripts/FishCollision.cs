using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollision : MonoBehaviour {

	public int value = 1;
    private Animator anim;


    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Shark").GetComponent<Animator>();
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Fish")) {
            anim.SetTrigger("Bite");
			GameProperties.instance.IncreaseScore(1);
			Destroy (other.gameObject);
		}
	}




}
