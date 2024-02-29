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
            //‚É‚ñ‚¶‚ñ‘¤‚ğÁ‚·

            //ƒEƒTƒM‘¤‚Ìbool–ß‚·
            m_rabbitAI.m_inCarrot = false;

            //‚È‚Â‚«“x‚ğ‚ ‚°‚é
           RabbitAI.m_natuki += 1;
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //‚¨‚Ñ‚¦‚é
            RabbitAI.m_natuki -= 1;
        }
    }
   
}
