using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


	public GameObject prefab;
	public Vector2 impulse = new Vector2(3,3);
	public float timeBetweenSpawns = 10f;


	private float timeTillSpawn = 3f;

	
	// Update is called once per frame
	void Update () {
		if (timeTillSpawn <= 0) {
			timeTillSpawn = Random.Range (0, timeBetweenSpawns);
			GameObject obj = GameObject.Instantiate (prefab);
			obj.transform.parent = transform;
			obj.transform.position = transform.position;
			Impulse i = obj.AddComponent<Impulse> ();
			i.impulse = impulse;

		} else {
			timeTillSpawn = timeTillSpawn - Time.deltaTime;
		}
	}
}
