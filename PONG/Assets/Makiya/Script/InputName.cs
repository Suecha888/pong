using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class InputName : MonoBehaviourPunCallbacks
{
    public TMP_Text tmpName;
    public GameObject JoinButton;

    // プレイヤーの名前設定
    public void SetName()
    {
        TMP_Text text = GameObject.FindWithTag("Text").GetComponent<TMP_Text>();

        // 名前を表示する
        tmpName.text = text.text.ToString();
        // 名前を設定
        PhotonNetwork.NickName = text.text;
        //Debug.Log(PhotonNetwork.NickName);

        // InputFieldの文字を消去
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // Joinボタンの表示
        JoinButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
