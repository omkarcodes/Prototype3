using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 backGroundPos;
    float bound = -5;
    // Start is called before the first frame update
    void Start()
    {
        backGroundPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.x < bound)
        {
            transform.position = backGroundPos;
        }
    }
}
