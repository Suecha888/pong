using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarController : MonoBehaviourPunCallbacks
{
    public float speed = 3.0f;

    // Update is called once per frame
    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if(photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(speed * Time.deltaTime * input.normalized);

            // 上移動
            //if (Input.GetKey(KeyCode.W))
            //{
            //    transform.position += transform.up * speed * Time.deltaTime;
            //}
            // 下移動
            //if (Input.GetKey(KeyCode.S))
            //{
            //    transform.position -= transform.up * speed * Time.deltaTime;
            //}
        }
    }
}
