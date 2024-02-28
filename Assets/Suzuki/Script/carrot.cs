using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    private int carrotCount = 5; // �ŏ���5�{�̂ɂ񂶂�������Ă���

    public GameObject carrotPrefab; // �ɂ񂶂�̃v���t�@�u

    private List<GameObject> carrots = new List<GameObject>(); // �ɂ񂶂�̃C���X�^���X���i�[���郊�X�g

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

            // ������ɂ񂶂���\���ɂ���i��A�N�e�B�u���j
            GameObject consumedCarrot = carrots[carrotCount];
            consumedCarrot.SetActive(false);

            if (carrotCount == 0)
            {
                Debug.Log("�ɂ񂶂񂪂�������܂���I");
                // �S�Ă̂ɂ񂶂��j������
                DestroyAllCarrots();
            }
        }
    }

    void Start()
    {
        // �ŏ���5�{�̂ɂ񂶂�𐶐����ă��X�g�ɒǉ�
        for (int i = 0; i < carrotCount; i++)
        {
            GameObject carrot = Instantiate(carrotPrefab, transform.position, Quaternion.identity, transform);
            carrots.Add(carrot);
        }
    }

    // �v���C���[���ɂ񂶂�������Ă��邩�ǂ����𔻒肷�郁�\�b�h
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // �ɂ񂶂�̐���0���傫����΁A�v���C���[�͂ɂ񂶂�������Ă���
    }
    void DestroyAllCarrots()
    {
        foreach (GameObject carrot in carrots)
        {
            Destroy(carrot); // �e�ɂ񂶂�̃C���X�^���X��j��
        }
        carrots.Clear(); // ���X�g���N���A
    }
}

