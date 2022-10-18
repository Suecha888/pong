using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ShowScore : MonoBehaviourPunCallbacks,IPunObservable
{
    TextMeshProUGUI scoreText;
    // �X�R�A
    [SerializeField]
    int score = 0;
    // �X�R�A�擾��
    [SerializeField]
    string getscore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = new string(score.ToString());
    }
    // �X�R�A�\��
    public void ShowScoreText(int num,Data.win end)
    {
        if (end.flg)
        {
            end.name = getscore;
            return;
        }

        // �X�R�A���Z
        score += num;
        scoreText.text = new string(score.ToString());
        // �Q�[���I������
        if (score >= DontDestroy.instance.GetComponent<Setting>().GetMaxScore())
        {
            getscore = end.name;
            end.flg = true;
        }
        else
            end.flg = false;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(score);
            stream.SendNext(getscore);
        }
        else
        {
            score = (int)stream.ReceiveNext();
            getscore = (string)stream.ReceiveNext();
        }
    }
}
