using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBall : MonoBehaviour
{
    //�{�[���������������̖̂@���x�N�g��
    private Vector3 objNomalVector = Vector3.zero;
    // �{�[����rigidbody
    private Rigidbody rb;
    // ���˕Ԃ������verocity
    [HideInInspector] public Vector3 afterReflectVero = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        // �����������̖̂@���x�N�g�����擾
        objNomalVector = collision.contacts[0].normal;
        Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
        rb.velocity = reflectVec;
        // �v�Z�������˃x�N�g����ۑ�
        afterReflectVero = rb.velocity;
    }
}
