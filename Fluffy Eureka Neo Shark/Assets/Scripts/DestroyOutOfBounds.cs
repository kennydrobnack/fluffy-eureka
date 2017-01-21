using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {

	public float margin = 2f;

	void Update() {
		Camera camera = Camera.main;
		float height = 2f*camera.orthographicSize;
		float width = camera.aspect * height;
		Rect bounds = new Rect (camera.transform.position.x-.5f*(width+margin), camera.transform.position.y-.5f*(height+margin), width+margin, height+margin);
		if (!bounds.Contains (transform.position)) {
			Destroy (gameObject);
		}
	}
}
