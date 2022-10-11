using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace test
{


    public class Player : MonoBehaviourPun
    {
        public float speed = 3.0f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // ‘Šè‚Ì‘€ìŠ‚ÂÚ‘±’†
            if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            // ãˆÚ“®
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            // ‰ºˆÚ“®
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }
        }
    }
}
