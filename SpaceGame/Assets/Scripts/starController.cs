using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color c = spriteRenderer.color;
        c.a = 0;
        spriteRenderer.color = c;
    }

    // Update is called once per frame
    void Update()
    {
    	Color c = spriteRenderer.color;
        c.a =  Mathf.Clamp(c.a + (Time.deltaTime * direction),0,1);
        if(c.a == 1){
        	direction = -1;
        } else if (c.a == 0){
        	direction = 1;
        }

        spriteRenderer.color = c;
    }
}
