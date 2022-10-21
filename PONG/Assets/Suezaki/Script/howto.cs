using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howto : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;

    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void howtoClick()
    {
        // ‰¹‚ð–Â‚ç‚·
        audioSource.PlayOneShot(SE1);
    }
}
