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
            pos.x = 0;
        } else
        {
            pos.y = target.position.y + 1;
        }
        if (target.position.x < 2.5f)
        {
            pos.x = 2.5f;
        } else if(target.position.x > 30f)
        {
            pos.x = 30f;
        }
        else
        {
            pos.x = target.position.x;
        }
        
        
        transform.position = pos;
    }
}
