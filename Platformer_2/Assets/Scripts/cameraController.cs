using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(target.position.y < 0)
        {
            pos.y = 0;
        } else
        {
            pos.y = target.position.y;
        }
        if (target.position.x < -5f)
        {
            pos.x = -5f;
        } else if(target.position.x > 36f)
        {
            pos.x = 36f;
        }
        else
        {
            pos.x = target.position.x;
        }
        
        
        transform.position = pos;
    }
}
