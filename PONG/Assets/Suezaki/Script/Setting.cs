using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Setting : MonoBehaviour
{
    [SerializeField]
    int PlayerNum = 2;
    [SerializeField]
    int MaxScore = 15;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 20; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPlayerNum()
    {
        return PlayerNum;
    }

    public int GetMaxScore()
    {
        return MaxScore;
    }
}
