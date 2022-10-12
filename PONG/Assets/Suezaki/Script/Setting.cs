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
        PhotonNetwork.SendRate = 20; // 1�b�ԂɃ��b�Z�[�W���M���s����
        PhotonNetwork.SerializationRate = 10; // 1�b�ԂɃI�u�W�F�N�g�������s����
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
