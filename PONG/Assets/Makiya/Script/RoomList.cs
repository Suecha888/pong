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
            //Debug.Log("�폜���ꂽ��" + info.RemovedFromList);
            //if(info.PlayerCount <= 0)
            if (info.RemovedFromList)   // ���r�[�Ŏg�p����A���X�g�ɕ\������Ȃ��Ȃ������[���i�����A�I���A��\���j
            {
                //Debug.Log("���[���������F" + info.Name);
                dictionary.Remove(info.Name);
            }
            else
            {
                //Debug.Log("���[����ǉ��F" + info.Name);
                dictionary[info.Name] = info;
            }
            //Debug.Log("info���F" + info);
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
