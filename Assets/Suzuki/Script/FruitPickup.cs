using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FruitPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �؂̎����A�N�e�B�u�ɂ��āA�E��ꂽ��Ԃɂ���
            gameObject.SetActive(false);

            // �v���C���[�ɖ؂̎��������Ă����Ԃ�ʒm����i��q�j
            collision.GetComponent<PlayerController1>().PickupFruit();
        }
    }
}