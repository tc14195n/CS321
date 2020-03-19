using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public Transform target;
    int follow_adjust;
    // Start is called before the first frame update
    void Start()
    {
        follow_adjust = 1;
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x;
        pos.y = target.transform.position.y;
        transform.position = pos;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x - follow_adjust*2;
        pos.y = target.transform.position.y;
        transform.position = pos;
    }
}
