using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollector : MonoBehaviour
{

    [SerializeField]
    private Transform waveSpawner;
	private Rigidbody2D player;
	public float speedMultMax = 1.5f;
	public float speedMultMin = 1.2f;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wave", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Vector3 newPos = collision.transform.position;
            newPos.x = waveSpawner.position.x;
            collision.transform.position = newPos;
			MoveWave w = collision.GetComponent<MoveWave> ();
			float localSpeedMult = Random.Range (speedMultMin, speedMultMax);
			w.speed = localSpeedMult*Mathf.Abs (player.velocity.x);
        }
    }
}
