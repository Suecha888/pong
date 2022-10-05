using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2.0f;
    bool flg = true;
    private Rigidbody rb;
    // ボールが当たった物体の法線ベクトル
    private Vector3 objNomalVector = Vector3.zero;
    // 跳ね返った後のverocity
    private Vector3 afterReflectVero = Vector3.zero;
    public GameObject ball;

    public int ScorePlayerId = -1;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && flg)
        {
            rb.velocity = new Vector3(speed, speed, 0);
            // 発射時のvelocityを取得
            afterReflectVero = rb.velocity;
            flg = false;
            ScorePlayerId = -1;
        }

        // 画面外にボールが出た時
        if(transform.position.x >= 9 && !flg)
        {
            ScorePlayerId = 0;
        }
        else if(transform.position.x <= -9 && !flg)
        {
            ScorePlayerId = 1;
        }
    }
    public void StopBall()
    {
        flg = false;
    }
    public void ResetBall()
    {
        ScorePlayerId = -1;
        rb.velocity = Vector3.zero;
        gameObject.transform.position = Vector3.zero;
        flg = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 側面に当たったら消える
            if (collision.contacts[0].normal.x == 0)
            {
                if(rb.velocity.x > 0)
                    ScorePlayerId = 0;
                else
                    ScorePlayerId = 1;

                return;
            }

            

            float vecx;
            if (afterReflectVero.x > 0)
                vecx = -1;
            else
                vecx = 1;

            Vector3 returnVec = new Vector3(vecx, Random.Range(-1.0f, 1.0f), 0).normalized;
            rb.velocity = afterReflectVero.magnitude * returnVec;
            // 計算した反射ベクトルを保存
            afterReflectVero = rb.velocity;
        }

        if (collision.gameObject.tag == "Wall")
        {
            // 当たった物体の法線ベクトルを取得
            objNomalVector = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
            rb.velocity = reflectVec;
            // 計算した反射ベクトルを保存
            afterReflectVero = rb.velocity;
        }
    }
}