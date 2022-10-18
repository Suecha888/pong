using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Luncher : MonoBehaviourPunCallbacks
{
    [Tooltip("�P���[��������̍ő�l��")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    private string gameVersion = "1";

    private bool isConnecting;

    private bool switchFlg = false;
    private void Awake()
    {
        // MasterClient�ȊO��Client���V�[���̐؂�ւ����AMasterClient�̃V�[���̐؂�ւ��ɓ���
        PhotonNetwork.AutomaticallySyncScene = true;
        // PhotonNetwork���p�P�b�g���A1�b�ɉ��x���M���邩
        PhotonNetwork.SendRate = 120;
        // OnPhotonSerialize��PhotonView�ɁA1�b���x�Ă΂�邩
        // PhotonNetwork.sendRate�Ɗ֘A�����āA���̒l�����߂Ă��������B
        PhotonNetwork.SerializationRate = 120;
    }
   

    // �}�X�^�[�T�[�o�[�ɐڑ����ă��[���ɓ���
    public void Connect()
    {
        // �ڑ����Ă����烉���_���ȃ��[���ɎQ��
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
            isConnecting = PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region MonoBehaviourPunCallbacks Callbacks

    // �N���C�A���g��Master Server�ɐڑ�����Ă��āA�}�b�`���C�L���O�₻�̑��̃^�X�N���s���������������Ƃ��ɌĂяo����܂��B
    public override void OnConnectedToMaster()
    {
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        Debug.Log("suezaki/Luncher: OnConnectedToMaster() was called by PUN");
    }
    // Photon�T�[�o�[����ؒf������ɌĂяo����܂��B
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("suezaki/Luncher: OnDisconnected() was called by PUN with reason {0}",cause);
    }
    // �O���OpJoinRandom�Ăяo�����T�[�o�[�Ŏ��s�����Ƃ��ɌĂяo����܂��B
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("suezaki/Luncher: OnJoinRandomFailed() was called by PUN No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }
    // ���̃N���C�A���g�����[�����쐬�������Q���������Ɋ֌W�Ȃ��ALoadBalancingClient�����[���ɓ������Ƃ��ɌĂяo����܂��B
    public override void OnJoinedRoom()
    {
        Debug.Log("suezaki/Luncher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }
    #endregion
}
