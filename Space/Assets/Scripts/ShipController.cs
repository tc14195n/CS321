using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 torque;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        torque = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            torque += transform.right;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            torque += -transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            torque += -transform.up;
        } else if (Input.GetKey(KeyCode.D))
        {
            torque += transform.up;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * 10.0f);
        rb.AddTorque(torque * 2.0f);
    }
}
