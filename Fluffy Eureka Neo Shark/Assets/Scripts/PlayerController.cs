using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool canJump = false;
	public float acceleration = 15f;
	public float maxVel = 15f;
	public float jump = 20f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetAxis("Horizontal") != 0)
        {
			Vector2 dir = new Vector2 (Input.GetAxis ("Horizontal") * rb.mass*acceleration, 0);
			rb.AddForce (dir, ForceMode2D.Force);
        }
		

        if (canJump && Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, 0);
            canJump = false;
        }

		if (rb.velocity.x > maxVel) {
			rb.velocity = new Vector2 (Mathf.Sign(rb.velocity.x)*maxVel, rb.velocity.y);
		}

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            canJump = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            canJump = false;
        }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            canJump = true;
        }
    }
}
