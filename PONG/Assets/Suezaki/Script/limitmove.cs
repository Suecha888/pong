using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitmove : MonoBehaviour
{
   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (transform.parent.position.y > 0)
            {
                GetComponentInParent<PlayerOnline>().status = PlayerOnline.STATUS.limit_up;
            }
            else
            {
                GetComponentInParent<PlayerOnline>().status = PlayerOnline.STATUS.limit_down;
            }
        }
    }
}
