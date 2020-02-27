using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSpinner : MonoBehaviour
{
    float rotateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed *= Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
