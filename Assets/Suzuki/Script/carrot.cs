using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    private int carrotCount = 5; // 最初は5本のにんじんを持っている

    public GameObject carrotPrefab; // にんじんのプレファブ

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rabbit"))
        {
            // ウサギとのトリガーイベントを処理
            ConsumeCarrot();
        }
    }

    void ConsumeCarrot()
    {
        if (carrotCount > 0)
        {
            carrotCount--; // にんじんの数を減らす
            Debug.Log("にんじんを1本消費しました。残りのにんじんの数: " + carrotCount);
        }
        else
        {
            Debug.Log("にんじんがもうありません！");
        }
    }

    void Start()
    {
        // 最初に5本のにんじんを生成
        for (int i = 0; i < carrotCount; i++)
        {
            Instantiate(carrotPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    // プレイヤーがにんじんを持っているかどうかを判定するメソッド
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // にんじんの数が0より大きければ、プレイヤーはにんじんを持っている
    }
}

