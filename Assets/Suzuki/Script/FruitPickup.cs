using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FruitPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 木の実を非アクティブにして、拾われた状態にする
            gameObject.SetActive(false);

            // プレイヤーに木の実を持っている状態を通知する（後述）
            collision.GetComponent<PlayerController1>().PickupFruit();
        }
    }
}