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
            //にんじん側を消す

            //ウサギ側のbool戻す
            m_rabbitAI.m_inCarrot = false;

           //「一番近いうさぎの」なつき度をあげる
           
           RabbitAI.m_natuki += 1;
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //おびえる
            RabbitAI.m_natuki -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fence"))
        {
            Debug.Log("!!!");
            RabbitAI.m_rabbitCount += 1;
            //Destroyする
            Destroy(rabbit);
        }
    }

}
