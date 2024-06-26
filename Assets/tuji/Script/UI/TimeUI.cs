using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private float m_time = 0.0f;
    private float m_nextTime = 0.0f;
    private float m_interval = 1.0f;

    public static int m_countMin1;
    public static int m_countMin10;
    public static int m_countHour1;
    public static int m_countHour10;

    [SerializeField] GameObject m_timeUI;

    // Start is called before the first frame update
    void Start()
    {
        m_countHour10 = 1;
        m_countHour1  = 7;
        m_countMin10  = 5;
        m_countMin1   = 6;

    }

    // Update is called once per frame
    void Update()
    {
        //時間を計測
        m_time += Time.deltaTime;

        if (m_time >= m_nextTime)
        {
            m_countMin1++;

            if(m_countMin1 / 10 == 1)
            {
                m_countMin10++;
                m_countMin1 = 0;
            }

            if(m_countMin10  / 6 == 1)
            {
                m_countHour1++;
                m_countMin10 = 0;
            }

            if (m_countHour1 / 10 == 1)
            {
                m_countHour10++;
                m_countHour1 = 0;
            }

            m_timeUI.GetComponent<TextMeshProUGUI>().text = 
                "PM" + m_countHour10.ToString() + m_countHour1.ToString()+":" + m_countMin10.ToString() + m_countMin1.ToString();
            
            // 次の動作時間を更新
            m_nextTime = m_time + m_interval; 
        }

    }
}
