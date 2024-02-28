using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    private float m_time;
    private float m_interval = 3.0f;

    [SerializeField] GameObject m_ctrlUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_time/600);

        // キー入力がない場合
        if (!Input.anyKey)
        {
            m_time++; 

            //UIをアクティブにする
            if (m_time / 600 >= m_interval)
            {
                m_ctrlUI.SetActive(true);
            }
        }
        else
        {
            //時間をリセット
            m_time = 0;
            m_ctrlUI.SetActive(false);
        }
    }
}
