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

    // �v���C���[�̖��O�ݒ�
    public void SetName()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���O��\������
        tmpName.text = Inputname.text.ToString();
        // ���O��ݒ�
        PhotonNetwork.NickName = Inputname.text;
        //Debug.Log(PhotonNetwork.NickName);

        // InputField�̕���������
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // InputField�ƃ{�^���̕�����ύX
        Placeholder.text = placeholder_text.ToString();
        Text_tmp.text = Texttmp_text.ToString();

        // Join�{�^���ƃe�L�X�g�̕\��
        JoinButton.SetActive(true);
        text.SetActive(true);
    }
}
