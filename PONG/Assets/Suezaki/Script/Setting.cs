using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Setting : MonoBehaviour
{
    // プレイヤーの数
    [SerializeField]
    int PlayerNum = 2;
    // 最大スコア
    [SerializeField]
    int MaxScore = 15;
    // ボールのバウンドがランダムかどうか
    [SerializeField]
    bool BallBoundRandom = false;
    // ボールの加速
    [SerializeField]
    bool BallAccel = false;

    bool oldBallBoundRandom;
    int oldMaxScore;
    bool oldBallAccel;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 20; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数
        oldMaxScore = 1;
        oldBallBoundRandom = false;
        oldBallAccel = false;
    }

    // リセット
    public void ResetSetting()
    {
        MaxScore = oldMaxScore;
        BallBoundRandom = oldBallBoundRandom;
        BallAccel = oldBallAccel;
    }

    // プレイヤーの数取得
    public int GetPlayerNum()
    {
        return PlayerNum;
    }

    // 最大スコア取得
    public int GetMaxScore()
    {
        return MaxScore;
    }
    // 最大スコアセット
    public void AddMaxScore()
    {
        MaxScore = (MaxScore % 100) + 1;
    }
    public void MinusMaxScore()
    {
        MaxScore--;
        if(MaxScore <= 0)
        {
            MaxScore += 100;
        }
    }

    // ボールの反射フラグ取得
    public bool GetBallBound()
    {
        return BallBoundRandom;
    }
    // ボールの反射の切替
    public void SwitchBallBound()
    {
        BallBoundRandom = !BallBoundRandom;
    }
    // ボールの加速フラグ取得
    public bool GetBallAccel()
    {
        return BallAccel;
    }
    // ボールの加速の切替
    public void SwitchBallAccel()
    {
        BallAccel = !BallAccel;
    }
}
