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
            //にんじん側を消す

            //ウサギ側のbool戻す
            m_rabbitAI.m_inCarrot = false;

           //なつき度をあげる
           RabbitAI.m_natuki += 1;
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //おびえる
            RabbitAI.m_natuki -= 1;
        }
    }
   
}
