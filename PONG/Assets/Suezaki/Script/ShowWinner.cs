using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWinner : MonoBehaviour
{
    [SerializeField]
    Color32 player1OfflineColor = Color.white;
    [SerializeField]
    Color32 player2OfflineColor = Color.white;
    TextMeshProUGUI win;
    // Start is called before the first frame update
    private void Awake()
    {
        win = GetComponent<TextMeshProUGUI>();
    }
    // èüé“ÇÃñºëOÇ
    public void showWinner(string name)
    {
        win.text = new string(name + " WIN!!");
    }
    // èüé“ÇÃñºëOÇ
    public void showWinnerOffline(string name)
    {
        
        if (name == "Player1")
            win.text = new string($"<color=#{ColorUtility.ToHtmlStringRGBA(player1OfflineColor):X}>" + name + "</color>" + " WIN!!");
        else if(name == "Player2")
            win.text = new string($"<color=#{ColorUtility.ToHtmlStringRGBA(player2OfflineColor):X}>" + name + "</color>" + " WIN!!");
        else
            win.text = new string(name + " WIN!!");
    }
}
