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
        // �R���[�`���J�n
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        miniGamePanel.SetActive(false);
        gameobj.SetActive(false);
        AddBallPower.Setflg = true;
        MiniGamePlayer.Setflg = true;
        // �ݒ�̃{�^����������悤�ɂ���
        Add.interactable = true;
        Minus.interactable = true;
        boundButton.interactable = true;
        accelButton.interactable = true;
        Back.interactable = true;
    }
}
