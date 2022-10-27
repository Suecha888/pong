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
            if (info.RemovedFromList)   // ���r�[�Ŏg�p����A���X�g�ɕ\������Ȃ��Ȃ������[���i�����A�I���A��\���j
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

    // �w�肵�����[�����̃��[����񂪂���Ύ擾����
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
