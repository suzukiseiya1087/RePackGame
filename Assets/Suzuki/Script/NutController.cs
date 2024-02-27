using UnityEngine;

public class NutController : MonoBehaviour
{
    private Vector2 startPosition;
    private Rigidbody2D rb;
    private bool hasStartedFalling = false; // 落下を開始したかどうかを追跡
    public float fallDistance = 30f; // 落下を開始する距離

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 初期状態では重力の影響を受けないように設定
    }

    void Update()
    {
        if (!hasStartedFalling)
        {
            float distance = Vector2.Distance(startPosition, transform.position);
            if (distance >= fallDistance)
            {
                rb.gravityScale = 1; // 重力の影響を受けるように設定
                hasStartedFalling = true; // 落下を開始したとマーク
            }
        }
    }
}
