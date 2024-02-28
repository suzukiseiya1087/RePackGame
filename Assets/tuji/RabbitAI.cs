using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : MonoBehaviour
{
    public bool m_inFox = false;
    public bool m_inCarrot = false;

    private bool m_obieru=false;

    //動いているか？
    private bool m_isMoving = false;
    private Vector2 m_targetPosition;
    private float m_moveStartTime;
    private float m_moveDuration;
    private float m_nextMoveTime = 0f;
    private float m_moveInterval = 4f; // 動作間隔
    public float m_speed = 0.5f; // 一定の速度

    //なつき度のオブジェクト
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
        Debug.Log(m_inCarrot);

        //おびえてるときは何もしない
        if (m_obieru==true)
        {
            return;
        }

        // 4秒おきに動作するようにする
        if (Time.time >= m_nextMoveTime)
        {
            MoveRand(Random.Range(0, 2)); // ランダムな値を渡す
            m_nextMoveTime = Time.time + m_moveInterval; // 次の動作時間を更新
        }

        if (m_isMoving)
        {
            // 移動中の処理
            float elapsedTime = Time.time - m_moveStartTime;
            float time = Mathf.Clamp01(elapsedTime / m_moveDuration);
            transform.position = Vector2.Lerp(transform.position, m_targetPosition, time);

            if (time >= 1.0f)
            {
                m_isMoving = false;
            }
        }

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
    /// ランダムで移動
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


        // 移動距離
        float distance = Random.Range(1, 4); 
        m_targetPosition = (Vector2)transform.position + direction * distance;

        // 移動時間を計算する
        m_moveDuration = distance / m_speed;

        m_moveStartTime = Time.time;
        m_isMoving = true;
    }

    /// <summary>
    /// なつき度ゲージ
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

    /// <summary>
    /// 諸々が範囲内に入った時
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {

        //きつねなら
        if (collision.gameObject.CompareTag("Fox"))
        {
            m_inFox = true;

            // アイテムに向かっての方向ベクトルを計算
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            //近づく速度
            Vector2 approachVelocity = direction * m_speed;

            // 速度を適用
            transform.Translate(approachVelocity * Time.deltaTime);

        }

        //にんじんなら
        if (collision.gameObject.CompareTag("Carrot"))
        {
            m_inCarrot = true;

            //きつね側を優先
            if (m_inFox)
            {
                return;
            }

            // アイテムに向かっての方向ベクトルを計算
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            //近づく速度
            Vector2 approachVelocity = direction * m_speed * 0.5f;

            // 速度を適用
            transform.Translate(approachVelocity * Time.deltaTime);
        }


    }
}
