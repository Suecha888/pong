using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 3.0f;

    public Player.STATUS status = Player.STATUS.normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // è„à⁄ìÆ
        if (Input.GetKey(KeyCode.UpArrow) && status != Player.STATUS.limit_up)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            status = Player.STATUS.normal;
        }
        // â∫à⁄ìÆ
        if (Input.GetKey(KeyCode.DownArrow) && status != Player.STATUS.limit_down)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            status = Player.STATUS.normal;
        }
    }
}
