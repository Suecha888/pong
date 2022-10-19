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
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWave();
    }

    private void MoveWave()
    {
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
            float sinWaveOffset = waveSinOffset * i;
            float sinWave = Mathf.Sin(Time.time + sinWaveOffset);
            vertex[vertexIndex + 0].y += sinWave * waveheight;
            vertex[vertexIndex + 1].y += sinWave * waveheight;
            vertex[vertexIndex + 2].y += sinWave * waveheight;
            vertex[vertexIndex + 3].y += sinWave * waveheight;
        }
        // �W�I���g���X�V
        for(int i = 0; i < text.textInfo.meshInfo.Length;++i)
        {
            //���b�V�������A���ۂ̃��b�V�����_�֔��f
            text.textInfo.meshInfo[i].mesh.vertices = text.textInfo.meshInfo[i].vertices;
            text.UpdateGeometry(text.textInfo.meshInfo[i].mesh, i);
           
        }
    }
}
