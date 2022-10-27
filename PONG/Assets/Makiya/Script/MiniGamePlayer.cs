using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{
    public float speed = 3.0f;
    Vector3 pos;
    public static bool Setflg = false;

    public enum STATUS
    {
        limit_up,
        limit_down,
        normal
    }
    public STATUS status = STATUS.normal;

    private void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Setflg)
        {
            SetPlayerPos();
            Setflg = false;
        }

        // 上移動
        if (Input.GetKey(KeyCode.W) && status != STATUS.limit_up)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
        // 下移動
        if (Input.GetKey(KeyCode.S) && status != STATUS.limit_down)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Cube2")
        {
            if (transform.position.y > 1.5f)
            {
                status = STATUS.limit_up;
            }
            else
            {
                status = STATUS.limit_down;
            }
        }
    }

    public void SetPlayerPos()
    {
        // 初期座標にセット
        this.transform.position = pos;
    }
}
