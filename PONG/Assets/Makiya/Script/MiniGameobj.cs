using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameobj : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;
    public GameObject miniGamePanel;
    public Button Add;
    public Button Minus;
    public Button boundButton;
    public Button accelButton;
    public Button Back;
    public Button Gamebutton;

    public GameObject gameobj;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickminiGameButton()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);
        miniGamePanel.SetActive(true);
        gameobj.SetActive(true);
        // �ݒ�̃{�^���������Ȃ�����
        Add.interactable = false;
        Minus.interactable = false;
        boundButton.interactable = false;
        accelButton.interactable = false;
        Back.interactable = false;
        Gamebutton.interactable = false;
    }
}
