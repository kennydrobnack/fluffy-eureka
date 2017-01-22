using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour {

    [SerializeField]
    private GameObject laser;

    private bool canFire = true;
    private float fireTimer = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (canFire && Input.GetAxis("Fire1") > 0)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 10f);
            var beam = (GameObject)Instantiate(laser, newPos, Quaternion.identity);
            beam.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 25f, ForceMode2D.Impulse);
            Destroy(beam, 1f);
            canFire = false;
            fireTimer = .5f;
        }

        if(!canFire)
        {
            if (fireTimer <= 0f)
            {
                canFire = true;
            }
            else
            {
                fireTimer -= Time.deltaTime;
            }
        }

    }
}
