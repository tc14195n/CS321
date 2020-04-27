using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Original Author: TJ Carlson
 * Date: 4-22-2020
 * 
 * Ground tiles
 * freeze x and z
 * when ground_tile_y == 0, freeze y
 * when ground_tile(fall), unfreeze y and let gravity drop it
 */
public class TileManager : MonoBehaviour
{

    //public BoxCollider OOB; //out-of-bounds
    public GameObject floor_tile;
    public List<GameObject> fall_tiles;
    public Transform player_pos;
    float last_tile = -5;
    // Start is called before the first frame update
    void Start()
    {
        //player_pos = GetComponent<Transform>();
        InvokeRepeating("skyTile", 1f, 1f);
        for(int i = -5; i <= 20; i++)
        {
            last_tile = i;
            floorTile(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_pos.position.z > last_tile - 20)
        {
            floorTile(last_tile++);
        }
        //check if they're OOB - remove ifso
    }
    private void FixedUpdate()
    {
        
    }
    void skyTile()
    {
        int tile = Random.Range(0, fall_tiles.Count);
        Vector3 pos = new Vector3(Random.Range(-5,5),Random.Range(5,10),Random.Range(10,15) + player_pos.position.z);
        //these values can be adjusted to increase difficulty e.g. generate sky_tiles further ahead ->> messes up the path
        Instantiate(fall_tiles[tile], pos, Random.rotation);
    }
    void floorTile(float z_pos)
    {
        //Vector3 pos = new Vector3(0, 0, z_pos);
        Transform new_pos = floor_tile.transform;
        new_pos.position = new Vector3(0, 0, z_pos);
        Instantiate(floor_tile);
    }
    
}
