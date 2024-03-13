using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMarker : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public GameObject minimapMarkerPrefab; // ミニマップマーカーのプレファブ

    private GameObject minimapMarkerInstance;

    void Start()
    {
        // マーカーのインスタンスを作成し、ミニマップのUIキャンバスに配置
        minimapMarkerInstance = Instantiate(minimapMarkerPrefab, Vector3.zero, Quaternion.identity);
        minimapMarkerInstance.transform.SetParent(GameObject.Find("MinimapCanvas").transform, false);
    }

    void Update()
    {
        // ミニマップ上での敵の相対位置を計算
        Vector3 minimapPosition = new Vector3(transform.position.x - player.position.x, transform.position.z - player.position.z, 0);
        // マーカーの位置を更新
        minimapMarkerInstance.transform.localPosition = minimapPosition;
    }

    private void OnDestroy()
    {
        // オブジェクトが破壊されたときにマーカーも破壊
        if (minimapMarkerInstance != null)
        {
            Destroy(minimapMarkerInstance);
        }
    }
}