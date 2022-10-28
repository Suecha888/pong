using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloffline1 : MonoBehaviour
{
    // ���x
    [SerializeField]
    public float speed = 5.0f;
    [Range(1, 3)]
    // ���x�̍ő�{��
    public int SpeedMaxMagnification = 2;
    // ����
    float startSpeed;
    [SerializeField]
    // �ō����x�܂ł̎���
    float TimeToMaxSpeed = 30.0f;
    // timer
    [SerializeField]
    float SpeedTimer = 0;
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
    // �{�[���̔��˂������_�����ǂ���
    private bool reflectRandom = false;
    // �{�[�����������邩�ǂ���
    private bool ballaccel = false;
    // �ŏ��̃o�E���h
    private bool firstbound = true;

    public AudioClip SE1;
    AudioSource audioSource;

    // �����蔻�胊�X�g
    [SerializeField]
    private List<GameObject> colList = new List<GameObject>();
    private bool doublehitflg = false;

    private bool sidehit0 = false;
    private bool sidehit1 = false;
    // Start is called before the first frame update
    void Start()
    {
        reflectRandom = DontDestroy.instance.GetComponent<Setting>().GetBallBound();
        ballaccel = DontDestroy.instance.GetComponent<Setting>().GetBallAccel();
        startSpeed = speed;
        rb = this.GetComponent<Rigidbody>();
        SetDir();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (flg)
        {
            // �{�[���X�^�[�g
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ����炷
                audioSource.PlayOneShot(SE1);
                StartBall();

            }
        }

        

        // �{�[������
        if (ballaccel)
        {
            if (!flg)
            {
                if (speed <= startSpeed * SpeedMaxMagnification)
                {


                    SpeedTimer += Time.deltaTime;
                    speed = startSpeed + (startSpeed * SpeedMaxMagnification - startSpeed) * (SpeedTimer - 0) / (TimeToMaxSpeed - 0);
                    rb.velocity = rb.velocity.normalized * speed;
                    afterReflectVero = rb.velocity;
                }
            }
        }

        // ��ʊO�Ƀ{�[�����o����
        if ((transform.position.x >= 9 && !flg) || sidehit0)
        {
            ScorePlayerId = 0;
            sidehit0 = false;
        }
        else if ((transform.position.x <= -9 && !flg) || sidehit1)
        {
            ScorePlayerId = 1;
            sidehit1 = false;
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
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Wall")
            colList.Remove(collision.gameObject);

        if (colList.Count == 0)
            doublehitflg = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (doublehitflg)
            return;

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Wall")
            colList.Add(collision.gameObject);

        // ����炷
        audioSource.PlayOneShot(SE1);

        // �ǂƃv���C���[�ɓ����ɓ�����
        if (colList.Count == 2)
        {
            Debug.Log("double");
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
            {
                // ���ʂɓ��������������
                if (collision.contacts[0].normal.x == 0)
                {
                    if (rb.velocity.x > 0)
                        sidehit0 = true;
                    else
                        sidehit1 = true;

                    return;
                }
            }
            int vecx;
            if (afterReflectVero.x > 0)
                vecx = -1;
            else
                vecx = 1;
            // ���˃����_��
            int angle = Random.Range(25, 45);
            if (transform.position.y > 0)
            {
                angle *= -1;
            }


            Vector3 returnVec = new Vector3(vecx, Mathf.Tan(angle * Mathf.Deg2Rad), 0).normalized;
            rb.velocity = afterReflectVero.magnitude * returnVec;

            // �v�Z�������˃x�N�g����ۑ�
            afterReflectVero = rb.velocity;
            doublehitflg = true;
            return;
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            // ���ʂɓ��������������
            if (collision.contacts[0].normal.x == 0)
            {
                if (rb.velocity.x > 0)
                    sidehit0 = true;
                else
                    sidehit1 = true;

                return;
            }



            float vecx;
            if (afterReflectVero.x > 0)
                vecx = -1;
            else
                vecx = 1;

            if (reflectRandom)
            {
                // ���˃����_��
                Vector3 returnVec = new Vector3(vecx, Random.Range(-1.0f, 1.0f), 0).normalized;
                rb.velocity = afterReflectVero.magnitude * returnVec;
            }
            else
            {
                if (firstbound)
                {
                    firstbound = false;
                    // ���˃����_��
                    int angle = Random.Range(25, 45);
                    if (Random.Range(1, 10) % 2 == 1)
                    {
                        angle *= -1;
                    }


                    Vector3 returnVec = new Vector3(vecx, Mathf.Tan(angle * Mathf.Deg2Rad), 0).normalized;
                    rb.velocity = afterReflectVero.magnitude * returnVec;
                }
                else
                {
                    // ���˕���
                    // �����������̖̂@���x�N�g�����擾
                    objNomalVector = collision.contacts[0].normal;
                    Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
                    rb.velocity = reflectVec;
                }
            }
            // �v�Z�������˃x�N�g����ۑ�
            afterReflectVero = rb.velocity;
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

        SpeedTimer = 0;
        speed = startSpeed;
        firstbound = true;
    }
    private void StartFlg()
    {
        startball = true;
    }
}