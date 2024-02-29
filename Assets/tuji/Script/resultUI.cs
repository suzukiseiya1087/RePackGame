using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resultUI : MonoBehaviour
{
    private TimeUI m_timeUI;
    private rabbitCount m_rabbit;
    //[SerializeField] private TextMeshProUGUI timeUI,rabbitCount;
    [SerializeField] private TextMeshProUGUI time, rabbit, fox;

    // Start is called before the first frame update
    void Start()
    {
        // TimeUI スクリプトがアタッチされたオブジェクトから TimeUI インスタンスを取得
        m_timeUI = FindObjectOfType<TimeUI>();
        // rabbitCount スクリプトがアタッチされたオブジェクトから rabbitCount インスタンスを取得
        m_rabbit = FindObjectOfType<rabbitCount>();
    }

    // Update is called once per frame
    void Update()
    {
        time.text="時間 PM"+ TimeUI.m_countHour10.ToString() + TimeUI.m_countHour1.ToString() +
            ":" + TimeUI.m_countMin10.ToString() + TimeUI.m_countMin1.ToString();

        rabbit.text = "うさぎを" + m_rabbit.ToString() + "匹戻した";
    }
}
