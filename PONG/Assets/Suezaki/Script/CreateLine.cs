using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateLine : MonoBehaviour
{
    // ���C�����\������P�s�[�X�̃I�u�W�F�N�g
    [SerializeField] GameObject line_peace;
    // �Z�b�g�̐�
    [SerializeField,Min(1)] int set_num;
    // �s�[�X�ƃs�[�X�̊Ԋu
    [SerializeField,Min(0)] float space;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < set_num; i++)
        {
            // �s�[�X�i��j
            GameObject peace_up = Instantiate(line_peace);
            peace_up.transform.position = new Vector3(0, space * i, 0);
            peace_up.transform.parent = transform;
            // �s�[�X�i���j
            GameObject peace_down = Instantiate(line_peace);
            peace_down.transform.position = new Vector3(0, -space * i, 0);
            peace_down.transform.parent = transform;
        }
    }

    public void ResetLine()
    {
        // �q�I�u�W�F�N�g�̍폜
        foreach (Transform child in gameObject.transform)
        {
            DestroyImmediate(child.gameObject);
        }
        // �X�V
        for (int i = 0; i < set_num; i++)
        {
            // �s�[�X�i��j
            GameObject peace_up = Instantiate(line_peace);
            peace_up.transform.position = new Vector3(0, space * i, 0);
            peace_up.transform.parent = transform;
            // �s�[�X�i���j
            GameObject peace_down = Instantiate(line_peace);
            peace_down.transform.position = new Vector3(0, -space * i, 0);
            peace_down.transform.parent = transform;
        }
    }

   
}
