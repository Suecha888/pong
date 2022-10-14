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
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 20; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数
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
}
