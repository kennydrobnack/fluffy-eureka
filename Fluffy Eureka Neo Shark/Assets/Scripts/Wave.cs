using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EdgeCollider2D))]
[RequireComponent (typeof(LineRenderer))]
public class Wave : MonoBehaviour {

	private EdgeCollider2D col;
	private LineRenderer lr;
	public int numPoints = 20;
	public float spacing = .2f;
	public float amplitude = .1f;
	public float frequency = 2f;
	public float wavelength = 1f;

	void Awake() {
		col = GetComponent<EdgeCollider2D> ();
		lr = GetComponent<LineRenderer> ();
	}
	// Use this for initialization
	void Start () {
		Vector2[] points = new Vector2[numPoints];
		for (int i = 0; i < numPoints; i++) {
			points [i] = new Vector2 (spacing*i, 0);
		}
		col.points = points;
		lr.numPositions = numPoints;
		lr.SetPositions (new Vector3[numPoints]);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2[] points = col.points;
		for (int i = 0; i < points.Length; i++) {
			float y = amplitude*Mathf.Sin (2f*Mathf.PI*wavelength*(points [i].x - frequency*Time.timeSinceLevelLoad));
			points [i].y = y;
			lr.SetPosition (i, new Vector3(transform.position.x + points[i].x, y));
		}
		col.points = points;


	}

	void OnDrawGizmos() {
		for (int i = 0; i < numPoints-1; i++) {
			float x1 = transform.position.x + spacing * i;
			float y1 = transform.position.y + amplitude*Mathf.Sin (2f*Mathf.PI*wavelength*x1);

			float x2 = transform.position.x + spacing * (i+1);
			float y2 = transform.position.y + amplitude*Mathf.Sin (2f*Mathf.PI*wavelength*x2);
			Gizmos.DrawLine (new Vector2 (x1, y1), new Vector2 (x2, y2));
		}
	}
}
