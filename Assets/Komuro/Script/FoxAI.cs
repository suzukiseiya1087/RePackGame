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

    // 狐の動く速度
    [SerializeField] Vector2 m_speed;
    private Vector2 m_velosity;

    // 時間
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;

    // Start is called before the first frame update
    public void Start()
    {
        m_position = transform.position;
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        m_velosity = m_speed;
        m_beforTime = 10;
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットにひきつけられているときに実行
        if(m_target != null && m_targetGet == false)
        {
            /*　ターゲットを追いかける　*/
            // 現在地から見たターゲットの方向

            // 現在地からターゲットへの最短距離（経路探索？）

            // ターゲットを追う

        }
        if(m_target == null)
        {
            m_targetGet = false;
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
        if (collision.gameObject.CompareTag("Nuts"))
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
        if (collision.gameObject.CompareTag("Nuts"))
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
        // ターゲットに追いついた
        m_targetGet = true;
        // 三秒間ターゲットの座標で停止

        // すべて終わったらターゲットをデリート（もしくは）
        m_target = null; 
        m_targetNuts = false; 
        m_targetRabbit = false;
        
    }

    private void MoveFox()
    {
        int direction = Random.Range(0, 5);
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
}
