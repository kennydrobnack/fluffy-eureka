using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class FlipSprite : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sprite;

    public bool flipX = true;
    public bool flipY = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (flipX) { 
		    if (rb.velocity.x > 0) {
			    sprite.flipX = true;
		    } else {
			    sprite.flipX = false;
		    }
        }

        if (flipY)
        {
            if (rb.velocity.y < 0)
            {
                sprite.flipY = true;
            }
            else
            {
                sprite.flipY = false;
            }
        }
	}
}
