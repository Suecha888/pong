using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks,IPunObservable
{
    // ���x
    public float speed = 2.0f;
    // �X�^�[�g���������t���O
    [SerializeField]
    bool flg = true;
    // �{�[���̏��L
    [SerializeField]
    string client;

    private Rigidbody rb;
    // �{�[���������������̖̂@���x�N�g��
    private Vector3 objNomalVector = Vector3.zero;
    // ���˕Ԃ������verocity
    private Vector3 afterReflectVero = Vector3.zero;

    // �X�R�A�擾��
    public int ScorePlayerId = -1;
    private int OldScorePlayerId = -1;

    // �{�[���̎ˏo������
    [SerializeField]
    private int dirX = 0;
    // �����Z�b�g
    private bool setDirFlg = false;
    // �N���C�A���g���{�[�����X�^�[�g�����t���O
    private bool startball = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        // �}�X�^�[�N���C�A���g�̂ݕ����Z�b�g
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
            // �N���C�A���g�̃X�^�[�g���󂯂ă}�X�^�[�N���C�A���g���X�^�[�g
            if(PhotonNetwork.IsMasterClient && startball)
            {
                StartBall();
                startball = false;
            }
            // �{�[���X�^�[�g
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(((dirX == -1) && (PhotonNetwork.IsMasterClient)))
                {
                    StartBall();
                }
                // �N���C�A���g�̓X�^�[�g�������̂ݓn��
                else if(((dirX == 1) && (!PhotonNetwork.IsMasterClient)))
                {
                    photonView.RPC(nameof(StartFlg), RpcTarget.All);
                }
                
            }
        }
        
        // �Ȍ�}�X�^�[�N���C�A���g�̂ݏ���
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        // ��ʊO�Ƀ{�[�����o����
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
    // �{�[�����X�^�[�g�ʒu�Ƀ��Z�b�g
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            // ���ʂɓ��������������
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
            // �v�Z�������˃x�N�g����ۑ�
            afterReflectVero = rb.velocity;
            Debug.Log(rb.velocity);
        }

        if (collision.gameObject.tag == "Wall")
        {
            // �����������̖̂@���x�N�g�����擾
            objNomalVector = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
            rb.velocity = reflectVec;
            // �v�Z�������˃x�N�g����ۑ�
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

    // �X�^�[�g���{�[���̎ˏo���������߂�
    // dirX  1:�E�@-1:��
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
        // ���ˎ���velocity���擾
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