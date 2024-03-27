using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1: MonoBehaviour
{
    private bool hasFruit = false;

    public GameObject fruitPrefab; // 木の実のプレハブ
    public Transform throwPoint; // 木の実を飛ばす起点

    public void PickupFruit()
    {
        hasFruit = true;
    }

    private void Update()
    {
        // 木の実を飛ばす処理（例えば、スペースキーを押したとき）
        if (Input.GetKeyDown(KeyCode.Space) && hasFruit)
        {
            // 木の実を非アクティブにして、拾われた状態にする
            gameObject.SetActive(false);
            ThrowFruit();
        }
    }

    private void ThrowFruit()
    {
        if (fruitPrefab && throwPoint)
        {
            Instantiate(fruitPrefab, throwPoint.position, Quaternion.identity);
            hasFruit = false; // 木の実を持っていない状態に戻す
        }
    }
}
