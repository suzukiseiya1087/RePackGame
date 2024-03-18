using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMarker : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public GameObject minimapMarkerPrefab; // �~�j�}�b�v�}�[�J�[�̃v���t�@�u

    private GameObject minimapMarkerInstance;

    void Start()
    {
        // �}�[�J�[�̃C���X�^���X���쐬���A�~�j�}�b�v��UI�L�����o�X�ɔz�u
        minimapMarkerInstance = Instantiate(minimapMarkerPrefab, Vector3.zero, Quaternion.identity);
        minimapMarkerInstance.transform.SetParent(GameObject.Find("MinimapCanvas").transform, false);
    }

    void Update()
    {
        // �~�j�}�b�v��ł̓G�̑��Έʒu���v�Z
        Vector3 minimapPosition = new Vector3(transform.position.x - player.position.x, transform.position.z - player.position.z, 0);
        // �}�[�J�[�̈ʒu���X�V
        minimapMarkerInstance.transform.localPosition = minimapPosition;
    }

    private void OnDestroy()
    {
        // �I�u�W�F�N�g���j�󂳂ꂽ�Ƃ��Ƀ}�[�J�[���j��
        if (minimapMarkerInstance != null)
        {
            Destroy(minimapMarkerInstance);
        }
    }
}