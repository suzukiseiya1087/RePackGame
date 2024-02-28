using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : MonoBehaviour
{
    public bool m_inFox = false;
    public bool m_inCarrot = false;

    private bool m_obieru=false;

    //�����Ă��邩�H
    private bool m_isMoving = false;
    private Vector2 m_targetPosition;
    private float m_moveStartTime;
    private float m_moveDuration;
    private float m_nextMoveTime = 0f;
    private float m_moveInterval = 4f; // ����Ԋu
    private float m_speed = 2f; // ���̑��x

    //�Ȃ��x�̃I�u�W�F�N�g
    [SerializeField] GameObject[] m_natukiObj;
    [SerializeField] Sprite[] m_sprites;
    private int m_natuki = 0;�@

     private void Update()
    {
        // 4�b�����ɓ��삷��悤�ɂ���
        if (Time.time >= m_nextMoveTime)
        {
            MoveRand(Random.Range(0, 2)); // �����_���Ȓl��n��
            m_nextMoveTime = Time.time + m_moveInterval; // ���̓��쎞�Ԃ��X�V
        }

        if (m_isMoving)
        {
            // �ړ����̏���
            float elapsedTime = Time.time - m_moveStartTime;
            float t = Mathf.Clamp01(elapsedTime / m_moveDuration);
            transform.position = Vector2.Lerp(transform.position, m_targetPosition, t);

            if (t >= 1.0f)
            {
                m_isMoving = false;
            }
        }

        Natuki();
        Debug.Log(m_natuki);

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_natuki++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_natuki--;
        }

        if (m_natuki >= 3)
        {
            m_natuki = 3;
        }

        if (m_natuki <= -3)
        {
            m_natuki = -3;
        }
    }

    private void MoveRand(int rand)
    {
        if (rand == 0 || m_isMoving || m_inFox || m_inCarrot)
        {
            return;
        }

        int dir = Random.Range(1, 5);
        Vector2 direction = Vector2.zero;

        switch (dir)
        {
            case 1:
                direction = Vector2.left;
                break;
            case 2:
                direction = Vector2.right;
                break;
            case 3:
                direction = Vector2.up;
                break;
            case 4:
                direction = Vector2.down;
                break;
        }

        float distance = Random.Range(1, 4); // �ړ�����
        m_targetPosition = (Vector2)transform.position + direction * distance;

        // �ړ����Ԃ��v�Z����
        m_moveDuration = distance / m_speed;

        m_moveStartTime = Time.time;
        m_isMoving = true;
    }

    private void Natuki()
    {
        if (m_natuki == 0)
        {
            m_natukiObj[m_natuki    ].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
            m_natukiObj[m_natuki + 1].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
            m_natukiObj[m_natuki + 2].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
        }

        if (m_natuki == 1)
        {
            m_natukiObj[m_natuki - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
            m_natukiObj[m_natuki].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
            m_natukiObj[m_natuki + 1].GetComponent<SpriteRenderer>().sprite = m_sprites[0];

        }
        if (m_natuki == 2)
        {
            m_natukiObj[m_natuki - 2].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
            m_natukiObj[m_natuki - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
            m_natukiObj[m_natuki    ].GetComponent<SpriteRenderer>().sprite = m_sprites[0];

        }
        if (m_natuki == 3)
        {
            m_natukiObj[m_natuki - 3].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
            m_natukiObj[m_natuki - 2].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
            m_natukiObj[m_natuki - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[1];
        }

        if (m_natuki == -1)
        {
            m_natukiObj[Mathf.Abs(m_natuki) - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
            m_natukiObj[Mathf.Abs(m_natuki) + 1].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
            m_natukiObj[Mathf.Abs(m_natuki)    ].GetComponent<SpriteRenderer>().sprite = m_sprites[0];

        }
        if (m_natuki == -2)
        {
            m_natukiObj[Mathf.Abs(m_natuki) - 2].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
            m_natukiObj[Mathf.Abs(m_natuki) - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
            m_natukiObj[Mathf.Abs(m_natuki)    ].GetComponent<SpriteRenderer>().sprite = m_sprites[0];

        }
        if (m_natuki == -3)
        {
            m_natukiObj[Mathf.Abs(m_natuki) - 3].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
            m_natukiObj[Mathf.Abs(m_natuki) - 2].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
            m_natukiObj[Mathf.Abs(m_natuki) - 1].GetComponent<SpriteRenderer>().sprite = m_sprites[2];
        }

    }
}
