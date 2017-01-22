using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	GameObject player;
	public float distScale = 1f;
	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = true;
	public float maxDist = 3;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 t = player.transform.position;
		float x = lockX ? transform.position.x : t.x;
		float y = lockY ? transform.position.y : t.y;
		float z = lockZ ? transform.position.z : t.z;
		Vector3 newPos = new Vector3 (x, y, z);

		float step = 0;
		if (Vector3.Distance (transform.position, newPos) < maxDist) {
			float speed = distScale * Vector3.Distance (transform.position, newPos);
			step = speed * Time.deltaTime;
		} else {
			float dist = Vector3.Distance (transform.position, newPos);
			step = dist - maxDist;
		}
		transform.position = Vector3.MoveTowards (transform.position, newPos, step);

	}
}
