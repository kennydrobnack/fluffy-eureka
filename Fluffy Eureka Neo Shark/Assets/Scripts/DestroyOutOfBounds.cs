using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {

	public float margin = 2f;

	void Update() {
		Camera camera = Camera.main;
		float width = camera.orthographicSize+margin;
		float height = camera.aspect * width+margin;
		Rect bounds = new Rect (camera.transform.position.x-.5f*width, camera.transform.position.y-.5f*height, width, height);
		if (!bounds.Contains (transform.position)) {
			Destroy (gameObject);
		}
	}
}
