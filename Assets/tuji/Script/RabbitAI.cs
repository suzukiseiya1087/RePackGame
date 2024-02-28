using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : MonoBehaviour
{
    public bool m_inFox = false;
    public bool m_inCarrot = false;
    public bool m_inFence = false;
    private bool m_obieru=false;

    //�����Ă��邩�H
    private bool m_isMoving = false;
    private Vector2 m_targetPosition;
    private float m_moveStartTime;
    private float m_moveDuration;
    private float m_nextMoveTime = 0f;
    private float m_moveInterval = 4f; // ����Ԋu
    public float m_speed = 0.5f; // ���̑��x

    //�Ȃ��x�̃I�u�W�F�N�g
    [SerializeField] GameObject[] m_natukiObj;
    [SerializeField] Sprite[] m_sprites;
    public int m_natuki = 0;


    [SerializeField] private Vector2[] m_firstPos;

    private void Start()
    {
        transform.position = m_firstPos[Random.Range(0,7)];
    }

    private void Update()
    {
        //Debug.Log(m_inCarrot);

        //���т��Ă�Ƃ��͉������Ȃ�
        if (m_obieru==true)
        {
            return;
        }

        // 4�b�����ɓ��삷��悤�ɂ���
        if (Time.time >= m_nextMoveTime)
        {
            MoveRand(Random.Range(0, 2)); // �����_���Ȓl��n��
            m_nextMoveTime = Time.time + m_moveInterval; // ���̓��쎞�Ԃ��X�V
        }

        // �ړ����̏���
        if (m_isMoving)
        {
            float elapsedTime = Time.time - m_moveStartTime;
            float time = Mathf.Clamp01(elapsedTime / m_moveDuration);
            transform.position = Vector2.Lerp(transform.position, m_targetPosition, time);

            if (time >= 1.0f)
            {
                m_isMoving = false;
            }
        }

        //�Ȃ��x
        Natuki();


        //Debug.Log(m_natuki);

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    m_natuki++;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    m_natuki--;
        //}

        if (m_natuki < 0)
        {
            m_obieru = true;
        }
        if (m_natuki >= 0)
        {
            m_obieru = false;
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

    /// <summary>
    /// �����_���ňړ�
    /// </summary>
    /// <param name="rand"></param>
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

        // �ړ�����
        float distance = Random.Range(1, 4); 
        m_targetPosition = (Vector2)transform.position + direction * distance;

        // �ړ����Ԃ��v�Z����
        m_moveDuration = distance / m_speed;

        m_moveStartTime = Time.time;
        m_isMoving = true;
    }

    /// <summary>
    /// �Ȃ��x�Q�[�W
    /// </summary>
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
            m_natukiObj[m_natuki    ].GetComponent<SpriteRenderer>().sprite = m_sprites[0];
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

    /// <summary>
    /// ���X���͈͓��ɓ�������
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {

        //���˂Ȃ�
        if (collision.gameObject.CompareTag("Fox"))
        {
            m_inFox = true;

            //��̒��ɂ���ꍇ
            if (m_inFence)
            {

            }

            // �A�C�e���Ɍ������Ă̕����x�N�g�����v�Z
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            //�������鑬�x
            Vector2 approachVelocity = direction * m_speed;

            // ���x��K�p
            transform.Translate(approachVelocity * Time.deltaTime);

        }

        //�ɂ񂶂�Ȃ�
        if (collision.gameObject.CompareTag("Carrot"))
        {
            m_inCarrot = true;

            //���ˑ���D��
            if (m_inFox)
            {
                return;
            }

            // �A�C�e���Ɍ������Ă̕����x�N�g�����v�Z
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            //�߂Â����x
            Vector2 approachVelocity = direction * m_speed * 0.5f;

            // ���x��K�p
            transform.Translate(approachVelocity * Time.deltaTime);
        }


    }
}