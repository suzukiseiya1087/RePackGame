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

        // �L�[���͂��Ȃ��ꍇ
        if (!Input.anyKey)
        {
            m_time++; 

            //UI���A�N�e�B�u�ɂ���
            if (m_time / 600 >= m_interval)
            {
                m_ctrlUI.SetActive(true);
            }
        }
        else
        {
            //���Ԃ����Z�b�g
            m_time = 0;
            m_ctrlUI.SetActive(false);
        }
    }
}
