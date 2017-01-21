using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public GameObject Fish;

    float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemy", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy ()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject aFish = (GameObject)Instantiate(Fish);
        aFish.transform.position = new Vector2(Random.Range(min.x, max.x), min.y);

        ScheduleNextFishSpawn();
    }

    void ScheduleNextFishSpawn()
    {
        float spawnInNumberOfSeconds = 2f;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNumberOfSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNumberOfSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnInNumberOfSeconds);
    }

}
