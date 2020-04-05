using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 50.0f, ForceMode.Impulse);

        Debug.LogError("Test");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 5.0f);
    }
    private void FixedUpdate()
    {
        
    }
}
