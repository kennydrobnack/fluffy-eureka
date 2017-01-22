using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour {

    public GameObject prefab;
    public float firstSpawnSeconds;
    public float min_x_impulse;
    public float max_x_impulse;
    public float min_y_impulse;
    public float max_y_impulse;

    public float min_x_pos;
    public float max_x_pos;
    public float min_y_pos;
    public float max_y_pos;

    public float minSpawnRateInSeconds;
    public float maxSpawnRateInSeconds;

    // Use this for initialization
    void Start()
    {
        Invoke("SpawnNewPrefab", firstSpawnSeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnNewPrefab()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(min_x_pos, min_y_pos));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(max_x_pos, max_y_pos));
        GameObject aThing = (GameObject)Instantiate(prefab);
        aThing.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        float x_impulse = Random.Range(min_x_impulse, max_x_impulse);
        float y_impulse = Random.Range(min_y_impulse, max_y_impulse);
        if (aThing.transform.position.x >= 0.5)
        {
            x_impulse = -x_impulse;
        }
        Vector2 impulse = new Vector2(x_impulse, y_impulse);
        Impulse i = aThing.AddComponent<Impulse>();
        i.impulse = impulse;
        ScheduleNextPrefabSpawn();
    }

    void ScheduleNextPrefabSpawn()
    {
        float spawnInNumberOfSeconds = Random.Range(minSpawnRateInSeconds, maxSpawnRateInSeconds);
        Invoke("SpawnNewPrefab", spawnInNumberOfSeconds);
    }
}




