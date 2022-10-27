using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitmoveoffline1 : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        // プレイヤーが壁と壁に囲まれた範囲でしか移動できないようにする
        if (collision.gameObject.tag == "Wall")
        {
            // 親オブジェクト（player）が中心より上ということは上の壁に接触しているということ
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
