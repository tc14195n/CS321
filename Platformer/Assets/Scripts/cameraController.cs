using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public int x_size;
    public Transform target;
    public SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        x_size = 18;
        float ortho = (player.bounds.size.x + x_size) * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = ortho;
    }

    // Update is called once per frame
    void Update()
    {

        float ortho = (player.bounds.size.x + x_size) * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = ortho;
    }
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }
}
