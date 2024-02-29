using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// 概要：狐の動きを管理するスクリプト
// 作成者：小室

public class FoxAI : MonoBehaviour
{
    // 狐の座標
    private Vector2 m_position;
    // 木の実にひきつけられているか
    private bool m_targetNuts;
    // ウサギにひきつけられているか
    private bool m_targetRabbit;
    // 追いかけているものの座標
    private Transform m_target;
    // ターゲットに追いついたかどうか
    private bool m_targetGet;
    // スポーン情報
    private SpawnFox _spawnFox;
    // ターゲットに追いついた後の経過時間
    private int m_targetGetTime;

    // 狐の動く速度
    [SerializeField] Vector2 m_speed;
    private Vector2 m_velosity;

    // 時間
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;

    // Start is called before the first frame update
    void Start()
    {
        m_position = transform.position;
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        m_velosity = m_speed;
        m_beforTime = 10;
        m_targetGetTime = 0;
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットにひきつけられているときに実行
        if(m_target != null && m_targetGet == false)
        {
            // スピードが入っているか
            if(m_speed.x == 0 && m_speed.y == 0)
            {
                m_speed = m_velosity;
            }

            /*　ターゲットを追いかける　*/
            // 現在地から見たターゲットの方向
            Vector2 direction;
            direction.x = m_target.position.x - transform.position.x;
            direction.y = m_target.position.y - transform.position.y;

            /*-----------------------------------------------------------------------------
             *
             *
             *          スピードが０になる原因以下のプログラムにあり
             *
             *
             ------------------------------------------------------------------------------*/
            // 右
            if (direction.x < 0)
            {
                m_speed.x = m_velosity.x;
            }
            // 左
            else if(direction.x > 0)
            {
                m_speed.x = -m_velosity.x;
            }
            // 上
            if(direction.y < 0)
            {
                m_speed.y = m_velosity.y;
            }
            // 下
            else if (direction.y > 0)
            {
                m_speed.y = -m_velosity.y;
            }


            // ターゲットを追う
            m_speed *= 2;

        }
        if(m_target == null)
        {
            m_targetGet = false;
        }
        // ターゲットを捕まえたときに実行
        if(m_targetGet == true && m_targetGetTime == 0)
        {
            m_targetGetTime = (int)m_foxTime.elapsedTime;
        }
        // ３秒たったら動き始める
        if((int)m_foxTime.elapsedTime - m_targetGetTime == 3)
        {
            m_targetGetTime = 0;
            m_target = null;
            m_targetNuts = false;
            m_targetRabbit = false;
            m_speed = m_velosity;
        }


        // 何も追いかけていないとき自由行動
        // 一定時間ごとに判定(3秒)
        int Time = (int)m_foxTime.elapsedTime;
        if(Time - m_beforTime == 3)
        {  
            // 動く方向を決める
            MoveFox();
            m_beforTime = Time;
        }

        // 狐を動かす
        m_position += m_speed;
        transform.position = m_position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 木の実がコライダー内に入ったら木の実の座標を受取る（ウサギより木の実優先）
        if (collision.gameObject.CompareTag("Nut"))
        {
            // 木の実にひきつけられているかどうか
            m_targetNuts = true;
            m_target = collision.gameObject.transform;
        }
        // ウサギが近くにいるときウサギの座標を受取る（障害物をよけて）
        else if (collision.gameObject.CompareTag("Rabbit") && m_targetNuts == false)
        {
            m_targetRabbit = true;
            m_target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 木の実がコライダー内から出たら木の実の座標を受け取る（ウサギより木の実優先）
        if (collision.gameObject.CompareTag("Nut"))
        {
            // 木の実にひきつけられているかどうか
            m_targetNuts = true;
            m_target = collision.gameObject.transform;
        }
        // ウサギが近くにいるときウサギの座標を受け取る（障害物をよけて）
        else if (collision.gameObject.CompareTag("Rabbit") && m_targetNuts == false)
        {
            m_targetRabbit = true;
            m_target = collision.gameObject.transform;
        }
    }

    // ターゲットと接触しているとき
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 木と接触した場合
        if(collision.gameObject.CompareTag("Wood"))
        {
            WoodMoveFox(collision);
            return;
        }

        // ターゲットに追いついた
        m_targetGet = true;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        MoveFox();
    }


    private void MoveFox()
    {
        int direction = Random.Range(0, 5);
        // ステージの端近くにいる場合
        

        // スピードをプラスにする
        m_speed = m_velosity;
        switch (direction)
        {
            case 0:     // 右
                m_speed.x *= 1;
                m_speed.y = 0;
                return;
            case 1:     // 左
                m_speed.x *= -1;
                m_speed.y = 0;
                return;
            case 2:     // 上
                m_speed.y *= 1;
                m_speed.x = 0;
                return;
            case 3:     // 下
                m_speed.y *= -1;
                m_speed.x = 0;
                return;
            case 4:     // その場で停止
                m_speed = Vector2.zero;
                return;

        }
    }

    private void WoodMoveFox(Collision2D collision)
    {
        GameObject Wood = collision.gameObject;
        Vector2 WoodPos = Wood.transform.position;
        float lengthx = WoodPos.x - transform.position.x;
        float lengthy = WoodPos.y - transform.position.y;
        int _N;
        if (Mathf.Abs(lengthx) > Mathf.Abs(lengthy))
        {
            _N = 1;
        }
        else
        {
            _N = 0;
        }

        if (_N == 0)
        {
            // 右によける
            if (WoodPos.x < transform.position.x)
            {
                m_speed.x *= 1;
                m_speed.y = 0;
            }
            // 左によける}
            if (WoodPos.x < transform.position.x)
            {
                m_speed.x *= -1;
                m_speed.y = 0;
            }
        }
        else if (_N == 1)
        {
            // 上によける
            if (WoodPos.y < transform.position.y)
            {
                m_speed.y *= 1;
                m_speed.x = 0;
            }
            // 下によける}
            if (WoodPos.y < transform.position.y)
            {
                m_speed.y *= -1;
                m_speed.x = 0;
            }
        }
    }
}
