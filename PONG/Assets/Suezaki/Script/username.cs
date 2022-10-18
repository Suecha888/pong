using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class username:MonoBehaviourPun
{
    // �}�X�^�[�N���C�A���g���ǂ���
    bool ismaster = false;
    // �ēǂݍ��݂��邩�ǂ���
    bool reload = false;
    private void Start()
    {
        // �}�X�^�[�N���C�A���g
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
            // �X�R�A�I�u�W�F�N�g�̖��O�ύX
            score.transform.GetChild(0).Find("Player1").name = photonView.Controller.NickName;
        }
        // �N���C�A���g
        else if ((PhotonNetwork.IsMasterClient && !photonView.IsMine) || (!PhotonNetwork.IsMasterClient && photonView.IsMine))
        {
            ismaster = false;
            if (photonView.Owner.NickName.Length == 0)
            {
                photonView.Owner.NickName = "cccclient";
            }
            // �ǂݍ��ݏ��ł܂���������Ă��Ȃ����Ƃ�����
            GameObject score = GameObject.FindGameObjectWithTag("score");
            if (score == null)
            {
                reload = true;
            }
            else
                // �X�R�A�I�u�W�F�N�g�̖��O�ύX
                score.transform.GetChild(0).Find("Player2").name = photonView.Controller.NickName;
            
        }

        // ���O�Z�b�g
        SetUserName();
    }

    private void Update()
    {
        // �ǂݍ��݂��o���ĂȂ��ꍇ������x���
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
    // ���O�Z�b�g
    public void SetUserName()
    {
        // �v���C���[��
        var nameLabel = this.GetComponent<TextMeshProUGUI>();
        nameLabel.text = photonView.Owner.NickName;
        // �\���ʒu
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
