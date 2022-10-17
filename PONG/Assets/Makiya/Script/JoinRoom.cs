using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject InputNamePanel;
    public GameObject RoomPanel;

    public void JoinButtonClicked()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        //Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ�����");
        // �p�l���̕\��/��\��
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
