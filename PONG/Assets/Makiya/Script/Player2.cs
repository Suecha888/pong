using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // è„à⁄ìÆ
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        // â∫à⁄ìÆ
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
    }
}
