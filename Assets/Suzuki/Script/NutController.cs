using UnityEngine;

public class NutController : MonoBehaviour
{
    private Vector2 startPosition;
    private Rigidbody2D rb;
    private bool hasStartedFalling = false; // �������J�n�������ǂ�����ǐ�
    public float fallDistance = 30f; // �������J�n���鋗��

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // ������Ԃł͏d�͂̉e�����󂯂Ȃ��悤�ɐݒ�
    }

    void Update()
    {
        if (!hasStartedFalling)
        {
            float distance = Vector2.Distance(startPosition, transform.position);
            if (distance >= fallDistance)
            {
                rb.gravityScale = 1; // �d�͂̉e�����󂯂�悤�ɐݒ�
                hasStartedFalling = true; // �������J�n�����ƃ}�[�N
            }
        }
    }
}
