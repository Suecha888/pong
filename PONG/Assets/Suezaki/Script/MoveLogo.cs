using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveLogo : MonoBehaviour
{
    [SerializeField, Min(0)]
    private float waveSinOffset = 1.0f;
    [SerializeField, Min(1)]
    private int waveheight = 1;
    private TMP_Text text;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float[] chartimer;
    [SerializeField]
    float[] pos;
    [SerializeField]
    int[] moveCount;
    int[] oldpos;
    [SerializeField]
    bool start = false;
    [SerializeField]
    float interval = 7.0f;
    [SerializeField]
    int waveNum = 2;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        chartimer = new float[10];
        pos = new float[4];
        moveCount = new int[4];
        oldpos = new int[4];

    }

    // Update is called once per frame
    void Update()
    {
        if(timer<0.0f)
        {
            start = false;
        }
        if(!start)
        {
            timer = interval;
            start = MoveWave(waveSinOffset,waveNum);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    // �g�̂悤�ɓ���
    private bool MoveWave(float delay,int num)
    {
        bool end = false;
        // ���b�V���X�V
        this.text.ForceMeshUpdate(true);
        
        
        // �ꕶ�����Ƃɓ�����
        for(int i = 0; i < text.textInfo.characterCount; ++i)
        {
            // �ꕶ���P�ʂ̏��
            var charInfo = text.textInfo.characterInfo[i];
            //Material�Q�Ƃ��Ă���index�擾
            int materialIndex = charInfo.materialReferenceIndex;
            //���_�Q�Ƃ��Ă���index�擾
            int vertexIndex = charInfo.vertexIndex;
            //�e�L�X�g�S�̂̒��_���i�[
            Vector3[] vertex = text.textInfo.meshInfo[materialIndex].vertices;

            Vector3 center = (vertex[vertexIndex + 0] + vertex[vertexIndex + 1] + vertex[vertexIndex + 2] + vertex[vertexIndex + 3])/4;

            pos[i] = vertex[vertexIndex + 0].y;

            if (chartimer[0] >= delay * i)
            {
                if(chartimer[0] == delay*i)
                {

                }
#if false
                if (chartimer[i] <= waveheight * num)
                {

                    chartimer[i] += Time.deltaTime;
                    float sinWave = Mathf.Sin(chartimer[i]);
                    vertex[vertexIndex + 0].y += sinWave * waveheight;
                    vertex[vertexIndex + 1].y += sinWave * waveheight;
                    vertex[vertexIndex + 2].y += sinWave * waveheight;
                    vertex[vertexIndex + 3].y += sinWave * waveheight;
                    end = false;
                }
                else
                {
                    if (pos[i] > vertex[vertexIndex + i].y)
                    {
                        chartimer[i] += Time.deltaTime;

                        float sinWave = Mathf.Sin(chartimer[i]);
                        vertex[vertexIndex + 0].y += sinWave * waveheight;
                        vertex[vertexIndex + 1].y += sinWave * waveheight;
                        vertex[vertexIndex + 2].y += sinWave * waveheight;
                        vertex[vertexIndex + 3].y += sinWave * waveheight;
                    }
                    else
                    {
                        end = true;
                    }

                }
#else
                if (moveCount[i] < num)
                {
                    
                    chartimer[i] += Time.deltaTime;
                    float sinWave = Mathf.Sin(chartimer[i]);

                    vertex[vertexIndex + 0].y += sinWave * waveheight;
                    vertex[vertexIndex + 1].y += sinWave * waveheight;
                    vertex[vertexIndex + 2].y += sinWave * waveheight;
                    vertex[vertexIndex + 3].y += sinWave * waveheight;
                    
                }
                else
                {

                }

                if(oldpos[i] == -1 && vertex[vertexIndex + 0].y > pos[i])
                {
                    moveCount[i]++;
                }

                if (vertex[vertexIndex + 0].y>pos[i])
                {
                    oldpos[i] = 1;
                }
                else
                {
                    oldpos[i] = -1;
                }
#endif
                if (moveCount[3] >= num)
                    end = true;
            }

        }
        // �W�I���g���X�V
        for(int i = 0; i < text.textInfo.meshInfo.Length;++i)
        {
            //���b�V�������A���ۂ̃��b�V�����_�֔��f
            text.textInfo.meshInfo[i].mesh.vertices = text.textInfo.meshInfo[i].vertices;
            text.UpdateGeometry(text.textInfo.meshInfo[i].mesh, i);
           
        }

        if (end)
        {
            for (int i = 0; i < 10; ++i)
                chartimer[i] = 0;
            for (int i = 0; i < 4; ++i)
            {
                oldpos[i] = 0;
                moveCount[i] = 0;
            }
        }
        return end;
    }
}
