using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCollision : MonoBehaviour
{
    RabbitAI m_rabbitAI;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            //�ɂ񂶂񑤂�����

            //�E�T�M����bool�߂�
            m_rabbitAI.m_inCarrot = false;

            //�Ȃ��x��������
           RabbitAI.m_natuki += 1;
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //���т���
            RabbitAI.m_natuki -= 1;
        }
    }
   
}
