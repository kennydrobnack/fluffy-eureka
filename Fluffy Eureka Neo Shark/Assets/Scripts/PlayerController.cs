using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal") * 100, 0);
            rb.AddForce(dir, ForceMode2D.Force);
        }
		
	}
}
