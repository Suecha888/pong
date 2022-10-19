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
        // メッシュ更新
        this.text.ForceMeshUpdate(true);
        
        // 一文字ごとに動かす
        for(int i = 0; i < text.textInfo.characterCount; ++i)
        {
            // 一文字単位の情報
            var charInfo = text.textInfo.characterInfo[i];
            //Material参照しているindex取得
            int materialIndex = charInfo.materialReferenceIndex;
            //頂点参照しているindex取得
            int vertexIndex = charInfo.vertexIndex;
            //テキスト全体の頂点を格納
            Vector3[] vertex = text.textInfo.meshInfo[materialIndex].vertices;
            float sinWaveOffset = waveSinOffset * i;
            float sinWave = Mathf.Sin(Time.time + sinWaveOffset);
            vertex[vertexIndex + 0].y += sinWave * waveheight;
            vertex[vertexIndex + 1].y += sinWave * waveheight;
            vertex[vertexIndex + 2].y += sinWave * waveheight;
            vertex[vertexIndex + 3].y += sinWave * waveheight;
        }
        // ジオメトリ更新
        for(int i = 0; i < text.textInfo.meshInfo.Length;++i)
        {
            //メッシュ情報を、実際のメッシュ頂点へ反映
            text.textInfo.meshInfo[i].mesh.vertices = text.textInfo.meshInfo[i].vertices;
            text.UpdateGeometry(text.textInfo.meshInfo[i].mesh, i);
           
        }
    }
}
