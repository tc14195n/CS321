using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player_pos;
    Transform camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        camera_pos = GetComponent<Transform>();
        Vector3 new_pos = player_pos.position;
        new_pos.z = player_pos.position.z + 10;
        new_pos.y = player_pos.position.y + 3;
        new_pos.x = player_pos.position.x;
        //camera_pos.position = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
