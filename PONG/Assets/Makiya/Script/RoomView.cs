using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{
    private const int MaxFlements = 20;

    [SerializeField]
    private RoomViewElement elementPrefab = default;

    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g
    private List<RoomViewElement> elementList = new List<RoomViewElement>(MaxFlements);
    private ScrollRect scrollRect;

    public void Init(MatchmakingView parentView)
    {
        scrollRect = GetComponent<ScrollRect>();

        // ���[�����X�g�v�f�i���[���Q���{�^���j�𐶐����ď���������
        for (int i = 0; i < MaxFlements; i++)
        {
            var element = Instantiate(elementPrefab, scrollRect.content);
            element.Init(parentView);
            element.Hide();
            elementList.Add(element);
        }
    }

    public override void OnJoinedLobby()
    {
        roomList.Clear();
    }

    public override void OnLeftLobby()
    {
        roomList.Clear();
    }

    public override void OnJoinedRoom()
    {
        roomList.Clear();
    }

    // �}�X�^�[�T�[�o�[�̃��r�[�ɂ���ԂɃ��[�����X�g���X�V���邽�߂ɌĂ΂��
    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        //Debug.Log("OnRoomListUpdate���Ă΂ꂽ");
        roomList.Update(changedRoomList);

        // ���݂��郋�[���̐��������[�����X�g�v�f��\������
        int index = 0;
        foreach (var roomInfo in roomList)
        {
            elementList[index++].Show(roomInfo);
        }
        // �c��̃��[�����X�g�v�f���\���ɂ���
        for (int i = index; i < MaxFlements; i++)
        {
            elementList[i].Hide();
        }
    }

}
