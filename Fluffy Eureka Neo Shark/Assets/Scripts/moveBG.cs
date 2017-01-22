using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour {

    void FixedUpdate()
    {
        Vector2 currPos = transform.position;
        currPos.x -= GameProperties.instance.GameSpeed * Time.deltaTime;
        transform.position = currPos;
    }
}
