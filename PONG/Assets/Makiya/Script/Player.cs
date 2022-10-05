using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public enum STATUS
    {
        limit_up,
        limit_down,
        normal
    }
    public STATUS status = STATUS.normal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // è„à⁄ìÆ
        if (Input.GetKey(KeyCode.W) && status != STATUS.limit_up)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
        // â∫à⁄ìÆ
        if (Input.GetKey(KeyCode.S) && status != STATUS.limit_down)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
    }

    
}