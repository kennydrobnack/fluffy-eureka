using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
	public float acceleration = 15f;
	public float maxVel = 15f;
	public float jump = 20f;
    private bool isGrounded = false;
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

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            SFXController.Instance.PlaySound(SoundEffect.Splash02);
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = jump;
            rb.velocity = newVelocity;
            isGrounded = false;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            SFXController.Instance.PlaySound(SoundEffect.Splash01);
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            isGrounded = false;
        }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            isGrounded = true;
        }
    }
}
