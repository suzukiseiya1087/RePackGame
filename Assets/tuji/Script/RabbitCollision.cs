using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static PlayerControl;

public class RabbitCollision : MonoBehaviour
{
    RabbitAI m_rabbitAI;

    [SerializeField] GameObject rabbit;

    private void Start()
    {
        //m_rabbitAI = FindObjectOfType<RabbitAI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("!!!!");

        if (collision.gameObject.CompareTag("Carrot"))
        {
           //if()

            //にんじん側を消す

            //ウサギ側のbool戻す
            m_rabbitAI.m_inCarrot = false;

            // 一番近いウサギのGameObjectを取得
            GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
            GameObject nearestRabbit = GetNearestRabbit(rabbits);

            if (nearestRabbit != null)
            {

                // 一番近いウサギのRabbitAIコンポーネントを取得
                RabbitAI nearestRabbitAI = nearestRabbit.GetComponent<RabbitAI>();

                if (nearestRabbitAI != null)
                {
                    // 一番近いウサギのなつき度を上げる
                    nearestRabbitAI.IncreaseNatuki();
                }
                else
                {
                    // nearestRabbit が null の場合の処理
                    Debug.Log("ラビットなんてねえよ");
                }
            }

        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //おびえる
            m_rabbitAI.m_natuki -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fence"))
        {
            //Debug.Log("!!!");
            RabbitAI.m_rabbitCount += 1;
            //Destroyする
            Destroy(rabbit);
        }
    }

    // 一番近いウサギを取得する関数
    GameObject GetNearestRabbit(GameObject[] rabbits)
    {
        GameObject nearestRabbit = null;
        float minDistance = Mathf.Infinity;
        Vector3 carrotPosition = transform.position;

        foreach (GameObject rabbit in rabbits)
        {
            float distance = Vector3.Distance(rabbit.transform.position, carrotPosition);
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestRabbit = rabbit;
            }
        }

        return nearestRabbit;
    }
}
