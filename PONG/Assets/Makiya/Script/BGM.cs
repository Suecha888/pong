using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ��ʑJ�ڂ��Ă��I�u�W�F�N�g�����Ȃ��悤�ɂ���
        DontDestroyOnLoad(this);
    }
}