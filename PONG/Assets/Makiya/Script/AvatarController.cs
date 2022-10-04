using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarController : MonoBehaviourPunCallbacks
{
    // Update is called once per frame
    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if(photonView.IsMine)
        {
            //var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            //transform.Translate(6f * Time.deltaTime * input.normalized);
        }
    }
}
