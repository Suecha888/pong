using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks,IPunObservable
{
    public float speed = 2.0f;
    [SerializeField]
    bool flg = true;
    [SerializeField]
    string client;
    private Rigidbody rb;
    // ボールが当たった物体の法線ベクトル
    private Vector3 objNomalVector = Vector3.zero;
    // 跳ね返った後のverocity
    private Vector3 afterReflectVero = Vector3.zero;
    public GameObject ball;

    public int ScorePlayerId = -1;
    private int OldScorePlayerId = -1;
    private GameObject message;

    [SerializeField]
    private int dirX = 0;
    private bool setDirFlg = false;

    private bool startball = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        if(PhotonNetwork.IsMasterClient)
        {
            SetDir();
            client = new string("Master");
        }else
        {

            client = new string("client");
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(flg)
        {
            if(PhotonNetwork.IsMasterClient && startball)
            {
                StartBall();
                startball = false;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(((dirX == -1) && (PhotonNetwork.IsMasterClient)))
                {
                    StartBall();
                }
                else if(((dirX == 1) && (!PhotonNetwork.IsMasterClient)))
                {
                    photonView.RPC(nameof(StartFlg), RpcTarget.All);
                }
                
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space) && flg)
        //{




        //}
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        // 画面外にボールが出た時
        if (transform.position.x >= 9 && !flg)
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
    public int GetBallDir()
    {
        return dirX;
    }
    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = Vector3.zero;
        flg = true;
        OldScorePlayerId = ScorePlayerId;
        ScorePlayerId = -1;
        SetDir();
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
            stream.SendNext(dirX);
        }
        else
        {
            ScorePlayerId = (int)stream.ReceiveNext();
            OldScorePlayerId = (int)stream.ReceiveNext();
            flg = (bool)stream.ReceiveNext();
            transform.position = (Vector3)stream.ReceiveNext();
            dirX = (int)stream.ReceiveNext();
        }
    }

    // スタート時ボールの射出方向を決める
    // dirX  1:右　-1:左
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
    private void StartBall()
    {
        Vector3 dir = new Vector3(dirX, 0, 0).normalized;
        rb.velocity = speed * dir;
        // 発射時のvelocityを取得
        afterReflectVero = rb.velocity;
        flg = false;
        setDirFlg = false;
    }

    [PunRPC]
    private void StartFlg()
    {
        startball = true;
    }
}