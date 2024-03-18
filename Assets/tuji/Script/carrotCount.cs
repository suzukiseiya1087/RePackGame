using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class carrotCount : MonoBehaviour
{
    RabbitAI rabbitAI;
    [SerializeField] TextMeshProUGUI m_countUI;

    private void Start()
    {
       //DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        m_countUI.text = "Å~" + PlayerControl.carrotCount;
    }
}
