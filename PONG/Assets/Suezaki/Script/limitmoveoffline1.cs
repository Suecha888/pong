using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitmoveoffline1 : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        // �v���C���[���ǂƕǂɈ͂܂ꂽ�͈͂ł����ړ��ł��Ȃ��悤�ɂ���
        if (collision.gameObject.tag == "Wall")
        {
            // �e�I�u�W�F�N�g�iplayer�j�����S����Ƃ������Ƃ͏�̕ǂɐڐG���Ă���Ƃ�������
            if (transform.parent.position.y > 0)
            {
                GetComponentInParent<playeroffline1>().status = playeroffline1.STATUS.limit_up;
            }
            else
            {
                GetComponentInParent<playeroffline1>().status = playeroffline1.STATUS.limit_down;
            }
        }
    }
}
