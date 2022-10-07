using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class InputName : MonoBehaviourPunCallbacks
{
    public TMP_Text tmpName;

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
        TMP_InputField deleteName = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        deleteName.text = "";
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
