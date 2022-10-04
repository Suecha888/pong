using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    int PlayerNum = 2;
    [SerializeField]
    int MaxScore = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPlayerNum()
    {
        return PlayerNum;
    }

    public int GetMaxScore()
    {
        return MaxScore;
    }
}
