using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    // スコア関連のイベントのリスト
    [HideInInspector]
    public List<UnityEvent<int,Data.win>> ScoreEvent = new List<UnityEvent<int,Data.win>>();
    // 勝者の名前をつたえるイベント
    [HideInInspector]
    public UnityEvent<string> WinnerEvent = new UnityEvent<string>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GetComponent<Setting>().GetPlayerNum(); ++i)
        {
            UnityEvent<int,Data.win> ShowScore = new UnityEvent<int,Data.win>();
            ScoreEvent.Add(ShowScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
