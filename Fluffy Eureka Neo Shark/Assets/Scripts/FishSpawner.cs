using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public GameObject Fish;
    public float min_x_impulse;
    public float max_x_impulse;
    public float min_y_impulse;
    public float max_y_impulse;

    public float maxSpawnRateInSeconds;

	// Use this for initialization
	void Start () {
        Invoke("SpawnFish", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnFish ()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject aFish = (GameObject)Instantiate(Fish);
        aFish.transform.position = new Vector2(Random.Range(min.x, max.x), min.y);
        float x_impulse = Random.Range(min_x_impulse, max_x_impulse);
        float y_impulse = Random.Range(min_y_impulse, max_y_impulse);
        if (aFish.transform.position.x <= 0.5)
        {
            x_impulse = -x_impulse;
        }
        Vector2 impulse = new Vector2(x_impulse, y_impulse);
        Impulse i = aFish.AddComponent<Impulse>();
        i.impulse = impulse;
        ScheduleNextFishSpawn();
    }

    void ScheduleNextFishSpawn()
    {
        float spawnInNumberOfSeconds = 0.002f;
        if (maxSpawnRateInSeconds > 0.0001f)
        {
            spawnInNumberOfSeconds = Random.Range(0.1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNumberOfSeconds = 0.001f;
        }
        Invoke("SpawnFish", spawnInNumberOfSeconds);
    }

}
