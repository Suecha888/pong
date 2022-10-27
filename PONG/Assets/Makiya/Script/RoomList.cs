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
            if (info.RemovedFromList)   // ロビーで使用され、リストに表示されなくなったルーム（満室、終了、非表示）
            {
                dictionary.Remove(info.Name);
            }
            else
            {
                dictionary[info.Name] = info;
            }
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
