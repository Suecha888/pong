using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rb;
    // �{�[���������������̖̂@���x�N�g��
    private Vector3 objNomalVector = Vector3.zero;
    // ���˕Ԃ������verocity
    private Vector3 afterReflectVero = Vector3.zero;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(speed, speed, 0);
            // ���ˎ���velocity���擾
            afterReflectVero = rb.velocity;
        }

        // ��ʊO�Ƀ{�[�����o����
        if(transform.position.x >= 11 || transform.position.x <= -11)
        {
            Instantiate(ball, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
        {
            // �����������̖̂@���x�N�g�����擾
            objNomalVector = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
            rb.velocity = reflectVec;

            // �v�Z�������˃x�N�g����ۑ�
            afterReflectVero = rb.velocity;
        }

    }
}