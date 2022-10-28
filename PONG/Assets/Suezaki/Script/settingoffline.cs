using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingoffline : MonoBehaviour
{
    // �v���C���[�̐�
    [SerializeField]
    int PlayerNum = 2;
    // �ő�X�R�A
    [SerializeField]
    int MaxScore = 15;
    // �{�[���̃o�E���h�������_�����ǂ���
    [SerializeField]
    bool BallBoundRandom = false;
    // �{�[���̉���
    [SerializeField]
    bool BallAccel = false;

    bool oldBallBoundRandom;
    int oldMaxScore;
    bool oldBallAccel;
    // Start is called before the first frame update
    void Start()
    {
        oldMaxScore = 1;
        oldBallBoundRandom = false;
        oldBallAccel = false;
    }

    // ���Z�b�g
    public void ResetSetting()
    {
        MaxScore = oldMaxScore;
        BallBoundRandom = oldBallBoundRandom;
        BallAccel = oldBallAccel;
    }

    // �v���C���[�̐��擾
    public int GetPlayerNum()
    {
        return PlayerNum;
    }

    // �ő�X�R�A�擾
    public int GetMaxScore()
    {
        return MaxScore;
    }
    public void SetMaxScore(int num)
    {
        MaxScore = num;
    }
    // �ő�X�R�A�Z�b�g
    public void AddMaxScore()
    {
        MaxScore = (MaxScore % 100) + 1;
    }
    public void MinusMaxScore()
    {
        MaxScore--;
        if (MaxScore <= 0)
        {
            MaxScore += 100;
        }
    }

    // �{�[���̔��˃t���O�擾
    public bool GetBallBound()
    {
        return BallBoundRandom;
    }
    // �{�[���̔��˂̐ؑ�
    public void SwitchBallBound()
    {
        BallBoundRandom = !BallBoundRandom;
    }
    // �{�[���̉����t���O�擾
    public bool GetBallAccel()
    {
        return BallAccel;
    }
    // �{�[���̉����̐ؑ�
    public void SwitchBallAccel()
    {
        BallAccel = !BallAccel;
    }
}