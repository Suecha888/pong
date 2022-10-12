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

    // �v���C���[�̖��O�ݒ�
    public void SetName()
    {
        TMP_Text text = GameObject.FindWithTag("Text").GetComponent<TMP_Text>();

        // ���O��\������
        tmpName.text = text.text.ToString();
        // ���O��ݒ�
        PhotonNetwork.NickName = text.text;
        //Debug.Log(PhotonNetwork.NickName);

        // InputField�̕���������
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // Join�{�^���̕\��
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
