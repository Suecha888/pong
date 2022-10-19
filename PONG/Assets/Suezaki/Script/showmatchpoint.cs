using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class showmatchpoint : MonoBehaviourPun
{
    public AudioClip SE1;
    AudioSource audioSource;

    // 何点マッチか
    int score = 0;
    // 表示テキスト
    TextMeshProUGUI maxscoreText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxscoreText = GetComponent<TextMeshProUGUI>();
        ShowMatchPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.A))
        //{
        //    photonView.RPC(nameof(SetMatchPointAdd), RpcTarget.All);
        //    //SetMatchPointAdd();
        //}
        //else if(Input.GetKey(KeyCode.D))
        //{
        //    photonView.RPC(nameof(SetMatchPointMinus), RpcTarget.All);
        //    //SetMatchPointMinus();
        //}
    }

    public void PointAddClick()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);
        photonView.RPC(nameof(SetMatchPointAdd), RpcTarget.All);
    }

    public void PointMinusClick()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);
        photonView.RPC(nameof(SetMatchPointMinus), RpcTarget.All);
    }

    public void ShowMatchPoint()
    {
        score = DontDestroy.instance.GetComponent<Setting>().GetMaxScore();
        maxscoreText.text = $"<color=#{matchsetting.TextColor.RED:X}>"+score.ToString()+"</color>" + " point match.";
    }
    [PunRPC]
    public void SetMatchPointAdd()
    {
        DontDestroy.instance.GetComponent<Setting>().AddMaxScore();
        ShowMatchPoint();
    }
    [PunRPC]
    public void SetMatchPointMinus()
    {
        DontDestroy.instance.GetComponent<Setting>().MinusMaxScore();
        ShowMatchPoint();
    }
}
