using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBallPower : MonoBehaviour
{
    private Rigidbody rb;
    private MiniGameBall bounceCalc;
    public float power = 1;    // 発射時の力
    public bool ballflg = true;
    public static bool Setflg = false;
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bounceCalc = this.GetComponent<MiniGameBall>();
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Setflg)
        {
            SetBall();
            Setflg = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && ballflg)
        {
            Vector3 dir = new Vector3(Random.Range(1, power), Random.Range(1, power), 0).normalized;
            rb.velocity = new Vector3(dir.x * power, dir.y * power, 0);
            // 発射時のvelocityを取得
            bounceCalc.afterReflectVero = rb.velocity;
            ballflg = false;
        }

        if (transform.position.x > 6 || transform.position.y < -3 || transform.position.y > 5)
        {
            rb.velocity = new Vector3(0, 0, 0);
            this.transform.position = pos;
            ballflg = true;
        }
    }

    public void SetBall()
    {
        // 初期座標にセット
        rb.velocity = new Vector3(0, 0, 0);
        this.transform.position = pos;
        ballflg = true;
    }
}
