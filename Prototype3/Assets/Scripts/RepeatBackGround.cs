using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 backGroundPos;
    float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        backGroundPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.x < backGroundPos.x - repeatWidth)
        {
            transform.position = backGroundPos;
        }
    }
}
