using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks,IPunObservable
{
    // 速度
    [SerializeField]
    public float speed = 5.0f;
    [Range(1,3)]
    // 速度の最大倍率
    public int SpeedMaxMagnification = 2;
    // 初速
    float startSpeed;
    [SerializeField]
    // 最高速度までの時間
    float TimeToMaxSpeed = 30.0f;
    // timer
    [SerializeField]
    float SpeedTimer = 0;
    // スタート準備完了フラグ
    [SerializeField]
    bool flg = true;
    // ボールの所有
    [SerializeField]
    string client;

    private Rigidbody rb;
    // ボールが当たった物体の法線ベクトル
    private Vector3 objNomalVector = Vector3.zero;
    // 跳ね返った後のverocity
    private Vector3 afterReflectVero = Vector3.zero;

    // スコア取得者
    public int ScorePlayerId = -1;
    private int OldScorePlayerId = -1;

    // ボールの射出方向ｘ
    [SerializeField]
    private int dirX = 0;
    // 方向セット
    private bool setDirFlg = false;
    // クライアントがボールをスタートしたフラグ
    private bool startball = false;
<<<<<<< HEAD
    // ボールの反射がランダムかどうか
    private bool reflectRandom = false;
    // ボールが加速するかどうか
    private bool ballaccel = false;
    // 最初のバウンド
    private bool firstbound = true;
=======

    public AudioClip SE1;
    AudioSource audioSource;
>>>>>>> 61e9730845d2b2ad96ba7b4dbee3af9be18c9758

    // Start is called before the first frame update
    void Start()
    {
        reflectRandom = DontDestroy.instance.GetComponent<Setting>().GetBallBound();
        ballaccel = DontDestroy.instance.GetComponent<Setting>().GetBallAccel();
        startSpeed = speed;
        rb = this.GetComponent<Rigidbody>();
        // マスタークライアントのみ方向セット
        if(PhotonNetwork.IsMasterClient)
        {
            SetDir();
            client = new string("Master");
        }else
        {

            client = new string("client");
        }

        audioSource = GetComponent<AudioSource>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(flg)
        {
            // クライアントのスタートを受けてマスタークライアントがスタート
            if(PhotonNetwork.IsMasterClient && startball)
            {
                StartBall();
                startball = false;
            }
            // ボールスタート
            if(Input.GetKeyDown(KeyCode.Space))
            {
                // 音を鳴らす
                audioSource.PlayOneShot(SE1);

                if (((dirX == -1) && (PhotonNetwork.IsMasterClient)))
                {
                    StartBall();
                }
                // クライアントはスタートした情報のみ渡す
                else if(((dirX == 1) && (!PhotonNetwork.IsMasterClient)))
                {
                    photonView.RPC(nameof(StartFlg), RpcTarget.All);
                }
                
            }
        }
        
        // 以後マスタークライアントのみ処理
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        // ボール加速
        if (ballaccel)
        {
            if (!flg)
            {
                if (speed <= startSpeed * SpeedMaxMagnification)
                {


                    SpeedTimer += Time.deltaTime;
                    speed = startSpeed + (startSpeed * SpeedMaxMagnification - startSpeed) * (SpeedTimer - 0) / (TimeToMaxSpeed - 0);
                    rb.velocity = rb.velocity.normalized* speed;
                    afterReflectVero = rb.velocity;
                }
            }
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
    // ボールをスタート位置にリセット
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
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
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

            if (reflectRandom)
            {
                // 反射ランダム
                Vector3 returnVec = new Vector3(vecx, Random.Range(-1.0f, 1.0f), 0).normalized;
                rb.velocity = afterReflectVero.magnitude * returnVec;
            }
            else
            {
                if (firstbound)
                {
                    firstbound = false;
                    // 反射ランダム
                    Vector3 returnVec = new Vector3(vecx, Random.Range(-1.0f, 1.0f), 0).normalized;
                    rb.velocity = afterReflectVero.magnitude * returnVec;
                }
                else
                {
                    // 反射物理
                    // 当たった物体の法線ベクトルを取得
                    objNomalVector = collision.contacts[0].normal;
                    Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
                    rb.velocity = reflectVec;
                }
            }
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

        SpeedTimer = 0;
        speed = startSpeed;
        firstbound = true;
    }

    [PunRPC]
    private void StartFlg()
    {
        startball = true;
    }
}