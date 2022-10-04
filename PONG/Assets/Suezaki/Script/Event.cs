using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    [HideInInspector]
    public List<UnityEvent<int>> ScoreEvent = new List<UnityEvent<int>>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; ++i)
        {
            UnityEvent<int> ShowScore = new UnityEvent<int>();
            ScoreEvent.Add(ShowScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
