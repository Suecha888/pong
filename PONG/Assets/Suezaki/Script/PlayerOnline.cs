using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PlayerOnline : MonoBehaviourPunCallbacks
{
    public float speed = 3.0f;
    public enum STATUS
    {
        limit_up,
        limit_down,
        normal
    }
    public STATUS status = STATUS.normal;
    

    // Update is called once per frame
    void Update()
    {
        
        // ëäéËÇÃëÄçÏ
        if(photonView.IsMine == false)
        {
            return;
        }
        // è„à⁄ìÆ
        if (Input.GetKey(KeyCode.W) && status != STATUS.limit_up)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
        // â∫à⁄ìÆ
        if (Input.GetKey(KeyCode.S) && status != STATUS.limit_down)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            status = STATUS.normal;
        }
    }
    
}

