using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class InputName : MonoBehaviourPunCallbacks
{
    public TMP_Text tmpName;
    public TMP_Text Inputname;
    public TMP_Text Placeholder;
    string placeholder_text;
    public TMP_Text Text_tmp;
    string Texttmp_text;
    public GameObject JoinButton;
    public GameObject text;
    public AudioClip SE1;
    AudioSource audioSource;

    private void Start()
    {
        placeholder_text = "nickName";
        Texttmp_text = "Rename";
        audioSource = GetComponent<AudioSource>();
    }

    // プレイヤーの名前設定
    public void SetName()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 名前を表示する
        tmpName.text = Inputname.text.ToString();
        // 名前を設定
        PhotonNetwork.NickName = Inputname.text;
        //Debug.Log(PhotonNetwork.NickName);

        // InputFieldの文字を消去
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // InputFieldとボタンの文字を変更
        Placeholder.text = placeholder_text.ToString();
        Text_tmp.text = Texttmp_text.ToString();

        // Joinボタンとテキストの表示
        JoinButton.SetActive(true);
        text.SetActive(true);
    }
}
