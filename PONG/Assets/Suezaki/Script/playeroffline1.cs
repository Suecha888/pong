using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeroffline1 : MonoBehaviour
{
    public float speed = 3.0f;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public enum STATUS
    {
        limit_up,
        limit_down,
        normal
    }
    public STATUS status = STATUS.normal;

    // Update is called once per frame
    void Update()
    {
        // è„à⁄ìÆ
        if (Input.GetKey(up) && status != STATUS.limit_up)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
        // â∫à⁄ìÆ
        if (Input.GetKey(down) && status != STATUS.limit_down)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
    }
}
