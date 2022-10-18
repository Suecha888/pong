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

    private RoomList roomList = new RoomList();     // 作成したルームのリスト
    private List<RoomViewElement> elementList = new List<RoomViewElement>(MaxFlements);
    private ScrollRect scrollRect;

    public void Init(MatchmakingView parentView)
    {
        scrollRect = GetComponent<ScrollRect>();

        // ルームリスト要素（ルーム参加ボタン）を生成して初期化する
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

    // マスターサーバーのロビーにいる間にルームリストを更新するために呼ばれる
    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        //Debug.Log("OnRoomListUpdateが呼ばれた");
        roomList.Update(changedRoomList);

        // 存在するルームの数だけルームリスト要素を表示する
        int index = 0;
        foreach (var roomInfo in roomList)
        {
            elementList[index++].Show(roomInfo);
        }
        // 残りのルームリスト要素を非表示にする
        for (int i = index; i < MaxFlements; i++)
        {
            elementList[i].Hide();
        }
    }

}
