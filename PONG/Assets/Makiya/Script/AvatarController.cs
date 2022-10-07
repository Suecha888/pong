using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarController : MonoBehaviourPunCallbacks
{
    public float speed = 3.0f;

    // Update is called once per frame
    private void Update()
    {
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if(photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(speed * Time.deltaTime * input.normalized);

            // ��ړ�
            //if (Input.GetKey(KeyCode.W))
            //{
            //    transform.position += transform.up * speed * Time.deltaTime;
            //}
            // ���ړ�
            //if (Input.GetKey(KeyCode.S))
            //{
            //    transform.position -= transform.up * speed * Time.deltaTime;
            //}
        }
    }
}
