using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitmove2 : MonoBehaviour
{
   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (transform.parent.position.y > 0)
            {
                GetComponentInParent<Player2>().status = Player.STATUS.limit_up;
            }
            else
            {
                GetComponentInParent<Player2>().status = Player.STATUS.limit_down;
            }
        }
    }
}
