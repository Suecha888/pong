using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScoreText(int num)
    {
        score += num;
        scoreText.text = new string(score.ToString());
    }
}
