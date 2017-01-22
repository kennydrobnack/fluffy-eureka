using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollector : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Destroy(collision);
        }
    }
}
