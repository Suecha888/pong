using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;
    public GameObject miniGamePanel;
    public Button Add;
    public Button Minus;
    public Button boundButton;
    public Button accelButton;
    public Button Back;
    public GameObject gameobj;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickBackButton()
    {
        // コルーチン開始
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        miniGamePanel.SetActive(false);
        gameobj.SetActive(false);
        AddBallPower.Setflg = true;
        MiniGamePlayer.Setflg = true;
        // 設定のボタンを押せるようにする
        Add.interactable = true;
        Minus.interactable = true;
        boundButton.interactable = true;
        accelButton.interactable = true;
        Back.interactable = true;
    }
}
