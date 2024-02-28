using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// 概要：狐の動きを管理するスクリプト
// 作成者：小室

public class FoxAI : MonoBehaviour
{
    // 狐の座標
    public Vector3 m_foxPos;
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

    // Start is called before the first frame update
    void Start()
    {
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        //// 初期座標設定
        //m_foxPos = _spawnFox._FoxPos;
        //this.gameObject.transform.position = m_foxPos;
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットにひきつけられているときに実行
        if(m_target != null)
        {
            /*　ターゲットを追いかける　*/
            // 現在地から見たターゲットの方向

            // 現在地からターゲットへの最短距離（経路探索？）

            // ターゲットを追う

        }
        

        // 何も追いかけていないとき自由行動
        // 一定時間ごとに判定
        // 動く方向を決める

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
        // 三秒間ターゲットの座標で停止

        // すべて終わったらターゲットをデリート（もしくは）

        
    }
}
