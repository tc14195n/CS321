using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTileController : MonoBehaviour
{
    bool falling = false;
    Transform tile_trans;
    Rigidbody tile_rb;
    // Start is called before the first frame update
    void Start()
    {
        tile_trans = GetComponent<Transform>();
        tile_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling)
        {
            //tile_rb.useGravity = false;
            if (tile_trans.position.y == 0)
            {
                //tile_rb.constraints |= RigidbodyConstraints.FreezePositionY;
                //tile_rb.useGravity = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sky_tile")
        {
            tile_rb.constraints = RigidbodyConstraints.None;
        }
    }
}
