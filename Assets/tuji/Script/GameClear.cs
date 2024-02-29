using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject;
    public float fadeDuration = 1.0f;
    private float currentAlpha = 0.0f;
    private float fadeSpeed;
    SpriteRenderer m_color;
    // Start is called before the first frame update
    void Start()
    {
        m_color=m_gameObject.GetComponent<SpriteRenderer>();

        // フェードの速度を計算
        fadeSpeed = 1.0f / fadeDuration;
    }

    // Update is called once per frame
    void Update()
    {

        if((TimeUI.m_countHour10==2&&TimeUI.m_countHour1==1)||RabbitAI.m_rabbitCount<0)
        {
            //Debug.Log("!!");
            //なんか演出
            currentAlpha += fadeSpeed * Time.deltaTime;
            m_color.color = new Color(m_color.color.r, m_color.color.g, m_color.color.b, Mathf.Clamp01(currentAlpha));
            if (currentAlpha >= 1.0f)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("Result");
            }
        }
    }
}
