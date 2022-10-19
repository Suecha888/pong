using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ENDClick()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);
        Application.Quit();
    }
}
