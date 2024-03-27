using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : MonoBehaviour
{

    private rabbitCount rabbitCount;

    public bool m_inFox = false;
    public bool m_inCarrot = false;
    public bool m_inFence = false;
    private bool m_obieru = false;

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
    public  int m_natuki = 0;

    public static int m_rabbitCount = 0;

    [SerializeField] private GameObject[] m_firstPos;

    [SerializeField] private GameObject m_bikkuri;


    private void Start()
    {
        transform.position = m_firstPos[Random.Range(0,rabbitCount.m_maxRabbit.Length)].transform.position;
        m_bikkuri.SetActive(false);

       // m_rabbitCount = rabbitCount.m_maxRabbit.Length;

    }

    private void Update()
    {
        //Debug.Log(m_rabbitCount);
        //m_inFox = false;
        //m_inCarrot = false;

        //おびえてるときは何もしない
        if (m_obieru==true)
        {
            return;
        }

        // 4秒おきに動作するようにする
        if (Time.time >= m_nextMoveTime && !m_obieru) 
        {
            MoveRand(Random.Range(0, 2)); // ランダムな値を渡す
            m_nextMoveTime = Time.time + m_moveInterval; // 次の動作時間を更新
        }

        // 移動中の処理
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

        //なつき度
        Natuki();

        if (m_natuki < 0)
        {
            m_obieru = true;
        }
        if (m_natuki >= 0)
        {
            m_obieru = false;
        }

        // なつき度が上限または下限を超えないように調整
        m_natuki = Mathf.Clamp(m_natuki, -3, 3);


        if(m_inFox)
        {
            //びっくりさせる
            m_bikkuri.SetActive(true);

        }
        else
        {
            m_bikkuri.SetActive(false);
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
                Flip(dir);
                break;
            case 2:
                direction = Vector2.right;
                Flip(dir);
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

            //遠ざかる速度
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

            //m_natuki++;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            m_inFox = false;
        }

        if (collision.gameObject.CompareTag("Carrot"))
        {
            m_inCarrot = false;
        }
    }


    // オブジェクトをフリップする関数
    private void Flip(int dir)
    {
        // オブジェクトのスケールを取得
        Vector2 scale = transform.localScale;

        // X 軸のスケールを反転させる
        if (scale.x > 0 && dir == 2) 
        {
            scale.x *= -1;
        }

        if(scale.x < 0 && dir == 1)
        {
            scale.x *= -1;
        }

        // 反転後のスケールを設定
        transform.localScale = scale;
    }

    public void Destroys()
    {
        Destroy(gameObject);
    }

    // なつき度を増加させるメソッド
    public void IncreaseNatuki()
    {
        m_natuki++;
        Debug.Log("なついた！" + m_natuki);
    }
}
