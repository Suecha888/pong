using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class RoomList : IEnumerable<RoomInfo>
{
    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public void Update(List<RoomInfo> changeRoomList)
    {
        foreach (var info in changeRoomList)
        {
            //Debug.Log("削除されたか" + info.RemovedFromList);
            //if(info.PlayerCount <= 0)
            if (info.RemovedFromList)   // ロビーで使用され、リストに表示されなくなったルーム（満室、終了、非表示）
            {
                //Debug.Log("ルームを消す：" + info.Name);
                dictionary.Remove(info.Name);
            }
            else
            {
                //Debug.Log("ルームを追加：" + info.Name);
                dictionary[info.Name] = info;
            }
            //Debug.Log("info情報：" + info);
        }
    }

    public void Clear()
    {
        dictionary.Clear();
    }

    // 指定したルーム名のルーム情報があれば取得する
    public  bool TryGetRoomInfo(string roomName, out RoomInfo roomInfo)
    {
        return dictionary.TryGetValue(roomName, out roomInfo);
    }

    public IEnumerator<RoomInfo> GetEnumerator()
    {
        foreach(var kvp in dictionary)
        {
            yield return kvp.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
