using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCollision : MonoBehaviour
{
    RabbitAI m_rabbitAI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            //にんじん側を消す

            //ウサギ側のbool戻す
            m_rabbitAI.m_inCarrot = false;

            //なつき度をあげる
            m_rabbitAI.m_natuki = 3;
        }


    }
}
