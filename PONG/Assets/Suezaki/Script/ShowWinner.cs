using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWinner : MonoBehaviour
{
    TextMeshProUGUI win;
    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showWinner(string name)
    {
        win.text = new string(name + " WIN!!");
    }
}
