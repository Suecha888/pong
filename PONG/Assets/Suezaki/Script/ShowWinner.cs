using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWinner : MonoBehaviour
{
    TextMeshProUGUI win;
    // Start is called before the first frame update
    private void Awake()
    {
        win = GetComponent<TextMeshProUGUI>();
    }
    // 勝者の名前を
    public void showWinner(string name)
    {
        win.text = new string(name + " WIN!!");
    }
}
