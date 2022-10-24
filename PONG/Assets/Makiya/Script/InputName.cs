using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class InputName : MonoBehaviourPunCallbacks
{
    public GameObject TitlePanel;
    public GameObject InputNamePanel;
    public TMP_Text tmpName;
    public TMP_Text Inputname;
    string noname;
    public TMP_Text namenum;
    int Maxname = 6;
    public TMP_Text Placeholder;
    string placeholder_text;
    public TMP_Text Text_tmp;
    string Texttmp_text;
    public GameObject JoinButton;
    public AudioClip SE1;
    AudioSource audioSource;

    private void Start()
    {
        noname = "Player";
        placeholder_text = "nickName";
        Texttmp_text = "Rename";
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 名前の文字数表示
        namenum.SetText("{0}/{1}", Inputname.text.Length - 1, Maxname);
    }

    // プレイヤーの名前設定
    public void SetName()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);
        // 名前が入力されていなかったら
        if (Inputname.text.Length == 1)
        {
            // 名前を表示する
            tmpName.text = "NickName : " + noname.ToString();
            // 名前を設定
            PhotonNetwork.NickName = noname;
        }
        else
        {
            // 名前を表示する
            tmpName.text = "NickName : " + Inputname.text.ToString();
            // 名前を設定
            PhotonNetwork.NickName = Inputname.text;
        }

        // InputFieldの文字を消去
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // InputFieldとボタンの文字を変更
        Placeholder.text = placeholder_text.ToString();
        Text_tmp.text = Texttmp_text.ToString();

        // Joinボタンとテキストの表示
        JoinButton.SetActive(true);
    }

    public void BackClick()
    {
        // コルーチン開始
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        TitlePanel.SetActive(true);
        InputNamePanel.SetActive(false);
    }
}
