﻿using UnityEngine;

public class MoveWave : MonoBehaviour {

    void FixedUpdate()
    {
        Vector3 currPos = transform.position;
        currPos.x += GameProperties.instance.GameSpeed * Time.deltaTime * .2f;
        transform.position = currPos;
    }
}
