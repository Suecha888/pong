using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showmatchpoint : MonoBehaviour
{
    // 何点マッチか
    int score = 0;
    // 表示テキスト
    TextMeshProUGUI maxscoreText;
    // Start is called before the first frame update
    void Start()
    {
        maxscoreText = GetComponent<TextMeshProUGUI>();
        ShowMatchPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMatchPoint()
    {
        score = DontDestroy.instance.GetComponent<Setting>().GetMaxScore();
        maxscoreText.text = score.ToString() + " point match.";
    }
    public void SetMatchPointAdd()
    {
        DontDestroy.instance.GetComponent<Setting>().AddMaxScore();
        ShowMatchPoint();
    }
    public void SetMatchPointMinus()
    {
        DontDestroy.instance.GetComponent<Setting>().MinusMaxScore();
        ShowMatchPoint();
    }
}
