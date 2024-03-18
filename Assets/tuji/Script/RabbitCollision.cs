using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCollision : MonoBehaviour
{
    RabbitAI m_rabbitAI;

    [SerializeField] GameObject rabbit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            //�ɂ񂶂񑤂�����

            //�E�T�M����bool�߂�
            m_rabbitAI.m_inCarrot = false;

           //�u��ԋ߂��������́v�Ȃ��x��������
           
           RabbitAI.m_natuki += 1;
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //���т���
            RabbitAI.m_natuki -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fence"))
        {
            Debug.Log("!!!");
            RabbitAI.m_rabbitCount += 1;
            //Destroy����
            Destroy(rabbit);
        }
    }

}
