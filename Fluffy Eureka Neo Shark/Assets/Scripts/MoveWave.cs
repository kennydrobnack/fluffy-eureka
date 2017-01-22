using UnityEngine;

public class MoveWave : MonoBehaviour {

	public float speed = 5f;
    void FixedUpdate()
    {
        Vector3 currPos = transform.position;
        currPos.x += speed * Time.deltaTime;
        transform.position = currPos;
    }
}
