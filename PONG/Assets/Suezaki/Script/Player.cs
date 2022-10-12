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
            // ����̑��슎�ڑ���
            if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            // ��ړ�
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            // ���ړ�
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }
        }
    }
}
