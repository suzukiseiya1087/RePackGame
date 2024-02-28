using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    private int carrotCount = 5; // 最初は5本のにんじんを持っている

    public GameObject carrotPrefab; // にんじんのプレファブ

    private List<GameObject> carrots = new List<GameObject>(); // にんじんのインスタンスを格納するリスト

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

            // 消費したにんじんを非表示にする（非アクティブ化）
            GameObject consumedCarrot = carrots[carrotCount];
            consumedCarrot.SetActive(false);

            if (carrotCount == 0)
            {
                Debug.Log("にんじんがもうありません！");
                // 全てのにんじんを破棄する
                DestroyAllCarrots();
            }
        }
    }

    void Start()
    {
        // 最初に5本のにんじんを生成してリストに追加
        for (int i = 0; i < carrotCount; i++)
        {
            GameObject carrot = Instantiate(carrotPrefab, transform.position, Quaternion.identity, transform);
            carrots.Add(carrot);
        }
    }

    // プレイヤーがにんじんを持っているかどうかを判定するメソッド
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // にんじんの数が0より大きければ、プレイヤーはにんじんを持っている
    }
    void DestroyAllCarrots()
    {
        foreach (GameObject carrot in carrots)
        {
            Destroy(carrot); // 各にんじんのインスタンスを破棄
        }
        carrots.Clear(); // リストをクリア
    }
}

