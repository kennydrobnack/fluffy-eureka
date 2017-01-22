using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 10f);
        Destroy((GameObject)Instantiate(Explosion, newPos, Quaternion.identity), 1f);
    }
}
