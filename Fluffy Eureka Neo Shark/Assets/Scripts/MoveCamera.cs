using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currPos = transform.position;
        currPos.x += GameProperties.instance.GameSpeed * Time.deltaTime;
        transform.position = currPos;
    }


}
