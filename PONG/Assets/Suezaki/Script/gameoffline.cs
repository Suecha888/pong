using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoffline : MonoBehaviour
{
    // �v���C���[�̃X�R�A�I�u�W�F�N�g
    [SerializeField] GameObject score;
    // �{�[��
    [SerializeField] GameObject ball;
    // �{�^���ē�
    [SerializeField] GameObject message;
    // �������
    [SerializeField]
    Data.win battle_data = new Data.win();

    // �����I������J�ڂ܂ł̎���
    [SerializeField] float EndToChangeTime = 1.0f;

    private bool scenechange = false;
    // Start is called before the first frame update
    void Start()
    {
        // �X�R�A�C�x���g�̓o�^
        for (int i = 0; i < score.transform.GetChild(0).transform.childCount; ++i)
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(0).transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);

    }

    // Update is called once per frame
    void Update()
    {
        if (battle_data.flg)
        {
            if (!scenechange)
            {
                message.SetActive(false);
                // �V�[���J��
                DontDestroy.instance.GetComponent<SceneChange>().Invoke("OfflineSceneChange", EndToChangeTime);
                ball.GetComponent<balloffline1>().StopBall();
                scenechange = true;
            }
        }
        else
        {



            

            // press ~~ �̕\��
            if (ball.GetComponent<balloffline1>().GetBallMoveFlg())
            {
                if (ball.GetComponent<balloffline1>().GetBallDir() == 1)
                {
                    message.transform.Find("right").gameObject.SetActive(true);
                }
                else
                {
                    message.transform.Find("left").gameObject.SetActive(true);
                }
                message.SetActive(true);
            }
            else
            {
                if (ball.GetComponent<balloffline1>().GetBallDir() == 1)
                {
                    message.transform.Find("right").gameObject.SetActive(false);
                }
                else
                {
                    message.transform.Find("left").gameObject.SetActive(false);
                }
                message.SetActive(false);
            }

            // �ǂ��炩�����_
            if (ball.GetComponent<balloffline1>().ScorePlayerId > -1)
            {
                // ���_����
                DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(0).transform.GetChild(ball.GetComponent<balloffline1>().ScorePlayerId).name;
                DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<balloffline1>().ScorePlayerId].Invoke(1, battle_data);
                // �{�[���̏�Ԃ����Z�b�g
                ball.GetComponent<balloffline1>().ResetBall();
            }

        }
    }
}
