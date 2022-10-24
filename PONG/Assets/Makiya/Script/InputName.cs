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
        // ���O�̕������\��
        namenum.SetText("{0}/{1}", Inputname.text.Length - 1, Maxname);
    }

    // �v���C���[�̖��O�ݒ�
    public void SetName()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);
        // ���O�����͂���Ă��Ȃ�������
        if (Inputname.text.Length == 1)
        {
            // ���O��\������
            tmpName.text = "NickName : " + noname.ToString();
            // ���O��ݒ�
            PhotonNetwork.NickName = noname;
        }
        else
        {
            // ���O��\������
            tmpName.text = "NickName : " + Inputname.text.ToString();
            // ���O��ݒ�
            PhotonNetwork.NickName = Inputname.text;
        }

        // InputField�̕���������
        TMP_InputField deleteName = GameObject.Find("InputNickname").GetComponent<TMP_InputField>();
        deleteName.text = "";

        // InputField�ƃ{�^���̕�����ύX
        Placeholder.text = placeholder_text.ToString();
        Text_tmp.text = Texttmp_text.ToString();

        // Join�{�^���ƃe�L�X�g�̕\��
        JoinButton.SetActive(true);
    }

    public void BackClick()
    {
        // �R���[�`���J�n
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        TitlePanel.SetActive(true);
        InputNamePanel.SetActive(false);
    }
}
