using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCountDown : MonoBehaviour
{
    private float m_time = 4.0f;

    //動いてよいかどうか
    public bool m_moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間を計測
        m_time -= Time.deltaTime;

        if(m_time < 0)
        {
            m_moveFlag=true;

           //Destroy(gameObject);
           gameObject.SetActive(false);
        }

        if (m_time < 1 && m_time > 0) 
        {
            this.GetComponent<TextMeshProUGUI>().text = "START";

            //アニメーションつけたい
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = ((int)m_time).ToString();

        }
    }
}
