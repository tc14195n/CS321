using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipController : MonoBehaviour
{
    public Text fuel_display;
    Rigidbody2D ship;
    Vector2 force;
    float fuel_max = 3.5f;
    float fuel; //determines how many movements the ship can make before running out
    float fuel_burn = 1; //should be positive. value is subtracted below
    // Start is called before the first frame update
    void Start()
    {
        fuel = fuel_max;
        fuel_display.text = "Fuel : " + string.Format("{0:0.#}",fuel/fuel_max*100) +"%";
        ship = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
            //controls for A, S, D
            if (fuel > 0 && Input.GetKey(KeyCode.A))
            {
                //move ship right
                force.x = 1f;
                ship.AddForce(force);
                updateFuel();
            }
            else if (fuel > 0 && Input.GetKey(KeyCode.D))
            {
                //move ship left
                force.x = 1f;
                ship.AddForce(-force);
                updateFuel();

            }
            if (fuel > 0 && Input.GetKey(KeyCode.S))
            {
                //move ship up
                //transform.Translate(Vector3.up * y_speed * Time.deltaTime);
                force.y = 4.1f;
                ship.AddForce(force);
                updateFuel();
            }
        
    }
    private void updateFuel()
    {
        fuel -= fuel_burn * Time.deltaTime;
        if (fuel < 0)
            fuel = 0;
        fuel_display.text = "Fuel : " + string.Format("{0:0.#}", fuel / fuel_max * 100) + "%";
    }
}
