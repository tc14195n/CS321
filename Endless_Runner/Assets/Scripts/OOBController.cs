using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBController : MonoBehaviour
{
    BoxCollider OOB;
    void Start()
    {
        OOB = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sky_tile" || other.tag == "floor_tile")
            Destroy(other.gameObject);
        if (other.tag == "player")
            GameData.setGameOver(true);
    }
}
