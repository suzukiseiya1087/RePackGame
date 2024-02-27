using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    public GameObject fencePrefab; // 柵のプレファブをアサイン
    private GameObject currentFence; // 現在の柵のインスタンスを保持
    public Transform playerTransform; // プレイヤーのTransform
    public float openDistance = 2f; // 開閉できる距離
    private void Start()
    {
        // ゲーム開始時に柵を生成
        currentFence = Instantiate(fencePrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        // 特定のキー（例えば「F」キー）が押されたら、かつプレイヤーが指定距離内にいる場合に柵を開閉
        if (Input.GetKeyDown(KeyCode.F) && distanceToPlayer <= openDistance)
        {
            // 柵が存在する場合はデストロイ、存在しない場合は生成
            if (currentFence != null)
            {
                Destroy(currentFence);
                currentFence = null;
            }
            else
            {
                currentFence = Instantiate(fencePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
