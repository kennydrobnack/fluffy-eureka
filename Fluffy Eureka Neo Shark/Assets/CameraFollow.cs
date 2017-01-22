using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	GameObject player;
	public float distScale = 1f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 t = player.transform.position;
		Vector3 newPos = new Vector3 (t.x, t.y, transform.position.z);

		float speed = distScale*Vector3.Distance (transform.position, newPos);
		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards (transform.position, newPos, step);
	}
}
