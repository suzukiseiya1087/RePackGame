using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    public GameObject fencePrefab; // ��̃v���t�@�u���A�T�C��
    private GameObject currentFence; // ���݂̍�̃C���X�^���X��ێ�
    public Transform playerTransform; // �v���C���[��Transform
    public float openDistance = 2f; // �J�ł��鋗��
    private void Start()
    {
        // �Q�[���J�n���ɍ�𐶐�
        currentFence = Instantiate(fencePrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        // ����̃L�[�i�Ⴆ�΁uF�v�L�[�j�������ꂽ��A���v���C���[���w�苗�����ɂ���ꍇ�ɍ���J��
        if (Input.GetKeyDown(KeyCode.F) && distanceToPlayer <= openDistance)
        {
            // �򂪑��݂���ꍇ�̓f�X�g���C�A���݂��Ȃ��ꍇ�͐���
            if (currentFence != null)
            {
                Destroy(currentFence);
                currentFence = null;
            }
            else
            {
                currentFence = Instantiate(fencePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
