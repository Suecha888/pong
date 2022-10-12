using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks,IPunObservable
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
    private int OldScorePlayerId = -1;
    private GameObject message;

    private int dirX = 0;
    private bool setDirFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if(flg)
        {
            SetDir();
            
            if(Input.GetKeyDown(KeyCode.Space) && (((dirX == -1)&&(PhotonNetwork.IsMasterClient))||((dirX == 1)&&(!PhotonNetwork.IsMasterClient))))
            {
                Vector3 dir = new Vector3(dirX, 0, 0).normalized;
                rb.velocity = speed * dir;
                // 発射時のvelocityを取得
                afterReflectVero = rb.velocity;
                flg = false;
                setDirFlg = false;
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space) && flg)
        //{
            
            

            
        //}

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
    public bool GetBallMoveFlg()
    {
        return flg;
    }
    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = Vector3.zero;
        flg = true;
        OldScorePlayerId = ScorePlayerId;
        ScorePlayerId = -1;
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

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(ScorePlayerId);
            stream.SendNext(OldScorePlayerId);
            stream.SendNext(flg);
            stream.SendNext(transform.position);
        }
        else
        {
            ScorePlayerId = (int)stream.ReceiveNext();
            OldScorePlayerId = (int)stream.ReceiveNext();
            flg = (bool)stream.ReceiveNext();
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }

    void SetDir()
    {
        if (setDirFlg)
            return;

        setDirFlg = true;
        switch (OldScorePlayerId)
        {
            case -1:
                {
                    if (Random.value > 0.5)
                        dirX = 1;
                    else
                        dirX = -1;
                    break;
                }
            case 0:
                {
                    dirX = 1;
                    break;
                }
            case 1:
                {
                    dirX = -1;
                    break;
                }

        }
    }
}