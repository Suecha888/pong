using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;
    string getscore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScoreText(int num,Data.win end)
    {
        if (end.flg)
        {
            end.name = getscore;
            return;
        }

        // �X�R�A���Z
        score += num;
        scoreText.text = new string(score.ToString());
        // �Q�[���I������
        if (score >= DontDestroy.instance.GetComponent<Setting>().GetMaxScore())
        {
            getscore = end.name;
            end.flg = true;
        }
        else
            end.flg = false;
    }
}
