using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    private int carrotCount = 5; // �ŏ���5�{�̂ɂ񂶂�������Ă���

    public GameObject carrotPrefab; // �ɂ񂶂�̃v���t�@�u

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rabbit"))
        {
            // �E�T�M�Ƃ̃g���K�[�C�x���g������
            ConsumeCarrot();
        }
    }

    void ConsumeCarrot()
    {
        if (carrotCount > 0)
        {
            carrotCount--; // �ɂ񂶂�̐������炷
            Debug.Log("�ɂ񂶂��1�{����܂����B�c��̂ɂ񂶂�̐�: " + carrotCount);
        }
        else
        {
            Debug.Log("�ɂ񂶂񂪂�������܂���I");
        }
    }

    void Start()
    {
        // �ŏ���5�{�̂ɂ񂶂�𐶐�
        for (int i = 0; i < carrotCount; i++)
        {
            Instantiate(carrotPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    // �v���C���[���ɂ񂶂�������Ă��邩�ǂ����𔻒肷�郁�\�b�h
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // �ɂ񂶂�̐���0���傫����΁A�v���C���[�͂ɂ񂶂�������Ă���
    }
}

