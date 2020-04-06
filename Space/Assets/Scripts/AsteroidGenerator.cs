using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public List<GameObject> asteroids;
    public int asteroid_count = 200;
    public float distance = 50;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < asteroid_count; i++)
        {
            int which = Random.Range(0, asteroids.Count);
            Vector3 position = Random.insideUnitSphere * distance;
            Instantiate(asteroids[which], position, Random.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
