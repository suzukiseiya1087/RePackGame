using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruit : MonoBehaviour
{
    public Transform throwPoint; // 投げる位置
    public GameObject fruitPrefab; // 木の実のPrefab
    public float throwForce = 10f; // 投げる力

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1はデフォルトでマウスの左クリックまたはCtrlキー
        {
            Throw();
        }
    }

    void Throw()
    {
        // 木の実のインスタンスを作成
        GameObject fruit = Instantiate(fruitPrefab, throwPoint.position, throwPoint.rotation);
        // 木の実に力を加えて投げる
        fruit.GetComponent<Rigidbody2D>().AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }
}