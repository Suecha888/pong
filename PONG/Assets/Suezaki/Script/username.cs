using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class username:MonoBehaviourPun
{
    // マスタークライアントかどうか
    bool ismaster = false;
    // 再読み込みするかどうか
    bool reload = false;
    private void Start()
    {
        // マスタークライアント
        if ((PhotonNetwork.IsMasterClient && photonView.IsMine) || (!PhotonNetwork.IsMasterClient && !photonView.IsMine))
        {
            ismaster = true;
            if (photonView.Owner.NickName.Length == 0)
            {
                photonView.Owner.NickName = "master";
            }

            GameObject score = GameObject.FindGameObjectWithTag("score");
            if(score == null)
            {
                reload = true;
            }else
            // スコアオブジェクトの名前変更
            score.transform.GetChild(0).Find("Player1").name = photonView.Controller.NickName;
        }
        // クライアント
        else if ((PhotonNetwork.IsMasterClient && !photonView.IsMine) || (!PhotonNetwork.IsMasterClient && photonView.IsMine))
        {
            ismaster = false;
            if (photonView.Owner.NickName.Length == 0)
            {
                photonView.Owner.NickName = "cccclient";
            }
            // 読み込み順でまだ生成されていないことがある
            GameObject score = GameObject.FindGameObjectWithTag("score");
            if (score == null)
            {
                reload = true;
            }
            else
                // スコアオブジェクトの名前変更
                score.transform.GetChild(0).Find("Player2").name = photonView.Controller.NickName;
            
        }

        // 名前セット
        SetUserName();
    }

    private void Update()
    {
        // 読み込みが出来てない場合もう一度やる
        if(reload)
        {
            reload = false;
            GameObject score = GameObject.FindGameObjectWithTag("score");
            if (ismaster)
            {
                if (score == null)
                {
                    reload = true;
                }
                else
                    score.transform.GetChild(0).Find("Player1").name = photonView.Controller.NickName;
            }
            else
            {
                if(score == null)
                {
                    reload = true;
                }
                else
                    score.transform.GetChild(0).Find("Player2").name = photonView.Controller.NickName;
            }
        }
    }
    // 名前セット
    public void SetUserName()
    {
        // プレイヤー名
        var nameLabel = this.GetComponent<TextMeshProUGUI>();
        nameLabel.text = photonView.Owner.NickName;
        // 表示位置
        var pos = this.GetComponent<RectTransform>();
        
        if (ismaster)
        {
            pos.localPosition = new Vector2(-200, 150);
        }
        else
        {
            pos.localPosition = new Vector2(200, 150);
        }
    }
   
}
