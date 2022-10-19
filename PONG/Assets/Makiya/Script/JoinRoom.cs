using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject InputNamePanel;
    public GameObject RoomPanel;
    public AudioClip SE1;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JoinButtonClicked()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
        //Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ�����");
        // �p�l���̕\��/��\��
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
