using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1: MonoBehaviour
{
    private bool hasFruit = false;

    public GameObject fruitPrefab; // �؂̎��̃v���n�u
    public Transform throwPoint; // �؂̎����΂��N�_

    public void PickupFruit()
    {
        hasFruit = true;
    }

    private void Update()
    {
        // �؂̎����΂������i�Ⴆ�΁A�X�y�[�X�L�[���������Ƃ��j
        if (Input.GetKeyDown(KeyCode.Space) && hasFruit)
        {
            // �؂̎����A�N�e�B�u�ɂ��āA�E��ꂽ��Ԃɂ���
            gameObject.SetActive(false);
            ThrowFruit();
        }
    }

    private void ThrowFruit()
    {
        if (fruitPrefab && throwPoint)
        {
            Instantiate(fruitPrefab, throwPoint.position, Quaternion.identity);
            hasFruit = false; // �؂̎��������Ă��Ȃ���Ԃɖ߂�
        }
    }
}
