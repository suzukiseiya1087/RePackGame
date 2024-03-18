using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rabbitCount : MonoBehaviour
{
    RabbitAI rabbitAI;
    [SerializeField] TextMeshProUGUI m_countUI;

    public GameObject[] m_maxRabbit;

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        int a = (int)RabbitAI.m_rabbitCount;
        m_countUI.text = "Å~" + a;
    }
}
