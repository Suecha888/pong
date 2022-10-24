using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject InputNamePanel;
    public GameObject RoomPanel;
    public AudioClip SE1;
    AudioSource audioSource;
    public Button JoinRoomButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // �{�^���������Ȃ�����
        JoinRoomButton.interactable = false;
        JoinRoomButton.onClick.AddListener(JoinButtonClicked);
    }

    public void JoinButtonClicked()
    {
        // ���[���쐬�{�^���������Ȃ�����
        JoinRoomButton.interactable = false;
        // Photon�T�[�o�[�ɐڑ����Ă��Ȃ�������
        if (!PhotonNetwork.IsConnected)
        {
            // ����炷
            audioSource.PlayOneShot(SE1);
            // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            // �R���[�`���J�n
            StartCoroutine("SetPanel");
        }
    }

    IEnumerator SetPanel()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ�");
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
        // �p�l���̕\��/��\��
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
