using UnityEngine;

public class SwitchDisp : MonoBehaviour
{
    private float m_time;
    private float m_interval = 2.0f;

    [SerializeField] CanvasGroup m_canvasGroup; 

    // Start is called before the first frame update
    void Start()
    {
        // CanvasGroup �R���|�[�l���g���擾
        m_canvasGroup = GetComponent<CanvasGroup>();

        // �����x��������
        m_canvasGroup.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_time++;

        // UI���A�N�e�B�u�ɂ���
        if (m_time / 600 >= m_interval)
        {
            //hyouji
            m_canvasGroup.alpha = 1.0f;
        }

        // �L�[���͂���������
        if (Input.anyKeyDown)
        {
            // ���Ԃ����Z�b�g
            m_time = 0;

            // ����
            m_canvasGroup.alpha = 0.0f;
        }
    }
}
