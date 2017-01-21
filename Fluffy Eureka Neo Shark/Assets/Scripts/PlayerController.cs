using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool canJump = false;
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
            Vector3 currPos = transform.position;
            currPos.x += Input.GetAxis("Horizontal") / 5f;
            transform.position = currPos;
        }

        Debug.Log(Input.GetAxis("Jump"));
        if (canJump && Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 10f, 0);
            canJump = false;
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
