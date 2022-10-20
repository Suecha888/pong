using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class showmatchpoint : MonoBehaviourPun
{
    public AudioClip SE1;
    AudioSource audioSource;
    public static bool reset = true;

    // ���_�}�b�`��
    int score = 0;
    // �\���e�L�X�g
    TextMeshProUGUI maxscoreText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxscoreText = GetComponent<TextMeshProUGUI>();
        ShowMatchPoint();
    }

    private void Update()
    {
        if (reset)
        {
            ShowMatchPoint();
            reset = false;
        }
    }

    public void PointAddClick()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);
        photonView.RPC(nameof(SetMatchPointAdd), RpcTarget.All);
    }

    public void PointMinusClick()
    {
        // ����炷
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
