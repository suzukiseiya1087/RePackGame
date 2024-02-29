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
        // TimeUI �X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g���� TimeUI �C���X�^���X���擾
        m_timeUI = FindObjectOfType<TimeUI>();
        // rabbitCount �X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g���� rabbitCount �C���X�^���X���擾
        m_rabbit = FindObjectOfType<rabbitCount>();
    }

    // Update is called once per frame
    void Update()
    {
        time.text="���� PM"+ TimeUI.m_countHour10.ToString() + TimeUI.m_countHour1.ToString() +
            ":" + TimeUI.m_countMin10.ToString() + TimeUI.m_countMin1.ToString();

        rabbit.text = "��������" + m_rabbit.ToString() + "�C�߂���";
    }
}
