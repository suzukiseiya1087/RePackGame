using UnityEngine;

public class UIMove : MonoBehaviour
{
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
    public void Open()
    {
        //hyouji
        m_canvasGroup.alpha = 1.0f;


    }
    public void Close()
    {
        //hyouji
        m_canvasGroup.alpha = 0.0f;

    }
}
