using UnityEngine;

public class SwitchDisp : MonoBehaviour
{
    private float m_time;
    private float m_interval = 2.0f;

    [SerializeField] CanvasGroup m_canvasGroup; 

    // Start is called before the first frame update
    void Start()
    {
        // CanvasGroup コンポーネントを取得
        m_canvasGroup = GetComponent<CanvasGroup>();

        // 透明度を初期化
        m_canvasGroup.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_time++;

        // UIをアクティブにする
        if (m_time / 600 >= m_interval)
        {
            //hyouji
            m_canvasGroup.alpha = 1.0f;
        }

        // キー入力があったら
        if (Input.anyKeyDown)
        {
            // 時間をリセット
            m_time = 0;

            // 透明
            m_canvasGroup.alpha = 0.0f;
        }
    }
}
