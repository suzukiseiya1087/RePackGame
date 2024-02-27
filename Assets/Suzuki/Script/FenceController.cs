using UnityEngine;

public class FenceController : MonoBehaviour
{
    public GameObject fencePrefab; // ��̃v���t�@�u��Inspector����ݒ�
    private GameObject currentFence; // ���݂̍�̃C���X�^���X��ێ�

    // ��̐����ʒu�i��Ƃ��āA���̃X�N���v�g���A�^�b�`�����I�u�W�F�N�g�̈ʒu�j
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position; // �����ʒu��ݒ�
        CreateFence(); // �Q�[���J�n���ɍ�𐶐�
    }

    void Update()
    {
        // Space�L�[�ō�̊J�𐧌�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFence != null)
            {
                DestroyFence(); // �򂪑��݂���ꍇ�A�j��
            }
            else
            {
                CreateFence(); // �򂪑��݂��Ȃ��ꍇ�A����
            }
        }
    }

    void CreateFence()
    {
        // ��̃v���t�@�u����V�����C���X�^���X�𐶐����A���݂̍�Ƃ��Đݒ�
        currentFence = Instantiate(fencePrefab, spawnPosition, Quaternion.identity);
    }

    void DestroyFence()
    {
        // ���݂̍��j��
        Destroy(currentFence);
        currentFence = null; // ���݂̍�̎Q�Ƃ��N���A
    }
}