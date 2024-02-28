using UnityEngine;

public class FenceController : MonoBehaviour
{
    public GameObject fencePrefab; // 柵のプレファブ
    public GameObject player; // プレイヤーオブジェクトをInspectorから設定

    private GameObject currentFence; // 現在の柵のインスタンス
    private Vector3 spawnPosition; // 柵の生成位置

    public float activationDistance = 1.2f; // プレイヤーがこの距離内に入ったらフェンスを開閉


    void Start()
    {
        spawnPosition = transform.position; // 初期位置を設定
        CreateFence(); // ゲーム開始時に柵を生成
    }

    void Update()
    {
        // プレイヤーとの距離を計算
        float distance = Vector3.Distance(player.transform.position, spawnPosition);

        // 距離がactivationDistance以下ならフェンスの開閉を可能にする
        if (distance <= activationDistance)
        {
            // Spaceキーで柵の開閉を制御
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleFence();
            }
        }
    }

    void ToggleFence()
    {
        if (currentFence != null)
        {
            DestroyFence(); // 柵が存在する場合、破棄
        }
        else
        {
            CreateFence(); // 柵が存在しない場合、生成
        }
    }

    void CreateFence()
    {
        // 柵のプレファブから新しいインスタンスを生成し、現在の柵として設定
        currentFence = Instantiate(fencePrefab, spawnPosition, Quaternion.identity);
    }

    void DestroyFence()
    {
        // 現在の柵を破棄
        Destroy(currentFence);
        currentFence = null; // 現在の柵の参照をクリア
    }
}
