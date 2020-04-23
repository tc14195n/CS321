using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject floor_tile;
    /*
     *SCRIPTNAME: TileController
     * Role: 
     * Attached to each tile prefab
     * Remove tiles when they drop below threshold
     * Generate floor tiles
     * floor tiles drop 5 seconds after player touches them 
     * 
     */
    //float TTF = 5; // time-to-fall : how many seconds before tile falls AFTER making contact with player
    //maybe TTF can be reduced the longer the player goes until the floor immediately starts dropping
    //float forward_generate = 20; // how many tiles ahead to generate for the path
    //float floor_y = 0, floor_x = 0;
    //float last_built = 0; //keeps track of the z-position of the last built floor tile. 
    public Transform player_pos;

    // Start is called before the first frame update
    void Start()
    {
        floor_tile = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void newFloorTile()
    {
        //start certain distance ahead of player and drop
        //start y==1 and @ y==0 stop gravity
    }
    void tileFall()
    {

    }
}
