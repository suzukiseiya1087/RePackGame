using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static PlayerControl;

public class RabbitCollision : MonoBehaviour
{
    RabbitAI m_rabbitAI;

    [SerializeField] GameObject rabbit;

    private Vector2 m_playerPosition;

    private void Start()
    {
        //m_rabbitAI = FindObjectOfType<RabbitAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Carrot"))
        {
           m_playerPosition = collision.transform.position;
            Debug.Log("!!!!");

            //�ɂ񂶂񑤂�����

            //�E�T�M����bool�߂�
            m_rabbitAI.m_inCarrot = false;

            // ��ԋ߂��E�T�M��GameObject���擾
            GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
            GameObject nearestRabbit = GetNearestRabbit(rabbits);

            if (nearestRabbit != null)
            {

                // ��ԋ߂��E�T�M��RabbitAI�R���|�[�l���g���擾
                RabbitAI nearestRabbitAI = nearestRabbit.GetComponent<RabbitAI>();

                if (nearestRabbitAI != null)
                {
                    // ��ԋ߂��E�T�M�̂Ȃ��x���グ��
                    nearestRabbitAI.IncreaseNatuki();
                }
                else
                {
                    // nearestRabbit �� null �̏ꍇ�̏���
                    Debug.Log("���r�b�g�Ȃ�Ă˂���");
                }
            }

        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            //���т���
            m_rabbitAI.m_natuki -= 1;
        }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        if (collision.CompareTag("Fence"))
        {
            //Debug.Log("!!!");
            RabbitAI.m_rabbitCount += 1;
            //Destroy����
            Destroy(rabbit);
        }
    }

    // ��ԋ߂��E�T�M���擾����֐�
    GameObject GetNearestRabbit(GameObject[] rabbits)
    {
        GameObject nearestRabbit = null;
        float minDistance = Mathf.Infinity;
        Vector3 Position = m_playerPosition;

        foreach (GameObject rabbit in rabbits)
        {
            float distance = Vector3.Distance(rabbit.transform.position, Position);
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestRabbit = rabbit;
            }
        }

        return nearestRabbit;
    }
}
