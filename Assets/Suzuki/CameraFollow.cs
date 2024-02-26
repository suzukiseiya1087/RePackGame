using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // プレイヤーのTransform
    public float smoothing = 5f; // カメラの動きを滑らかにするための値

    Vector3 offset; // カメラとプレイヤーの初期距離

    void Start()
    {
        // カメラとプレイヤーの初期位置関係を計算
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // カメラが目指すべき位置
        Vector3 targetCamPos = target.position + offset;
        // 現在の位置から目的の位置に向かって滑らかに移動
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}