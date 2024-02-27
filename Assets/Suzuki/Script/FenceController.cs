using UnityEngine;

public class FenceController : MonoBehaviour
{
    public GameObject fencePrefab; // 柵のプレファブをInspectorから設定
    private GameObject currentFence; // 現在の柵のインスタンスを保持

    // 柵の生成位置（例として、このスクリプトをアタッチしたオブジェクトの位置）
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position; // 初期位置を設定
        CreateFence(); // ゲーム開始時に柵を生成
    }

    void Update()
    {
        // Spaceキーで柵の開閉を制御
        if (Input.GetKeyDown(KeyCode.Space))
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