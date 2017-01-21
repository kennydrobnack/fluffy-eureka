using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollector : MonoBehaviour
{

    [SerializeField]
    private Transform waveSpawner;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Vector3 newPos = collision.transform.position;
            newPos.x = waveSpawner.position.x;
            collision.transform.position = newPos;
            //collision.transform.localScale = new Vector3(Random.Range(20f, 40f), Random.Range(20f, 40f), 1);
        }
    }
}
