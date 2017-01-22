using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject wave;

    [SerializeField]
    private float minTime, maxTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}
	
    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            Vector3 newPos = new Vector3(transform.position.x, -2.5f, 10f);
            Instantiate(wave, newPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
