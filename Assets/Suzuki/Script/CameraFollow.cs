using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �v���C���[��Transform
    public float smoothing = 5f; // �J�����̓��������炩�ɂ��邽�߂̒l

    Vector3 offset; // �J�����ƃv���C���[�̏�������

    void Start()
    {
        // �J�����ƃv���C���[�̏����ʒu�֌W���v�Z
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // �J�������ڎw���ׂ��ʒu
        Vector3 targetCamPos = target.position + offset;
        // ���݂̈ʒu����ړI�̈ʒu�Ɍ������Ċ��炩�Ɉړ�
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}