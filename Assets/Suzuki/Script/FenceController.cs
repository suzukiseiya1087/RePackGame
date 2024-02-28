using UnityEngine;

public class FenceController : MonoBehaviour
{
    public GameObject fencePrefab; // ��̃v���t�@�u
    public GameObject player; // �v���C���[�I�u�W�F�N�g��Inspector����ݒ�

    private GameObject currentFence; // ���݂̍�̃C���X�^���X
    private Vector3 spawnPosition; // ��̐����ʒu

    public float activationDistance = 1.2f; // �v���C���[�����̋������ɓ�������t�F���X���J��


    void Start()
    {
        spawnPosition = transform.position; // �����ʒu��ݒ�
        CreateFence(); // �Q�[���J�n���ɍ�𐶐�
    }

    void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distance = Vector3.Distance(player.transform.position, spawnPosition);

        // ������activationDistance�ȉ��Ȃ�t�F���X�̊J���\�ɂ���
        if (distance <= activationDistance)
        {
            // Space�L�[�ō�̊J�𐧌�
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleFence();
            }
        }
    }

    void ToggleFence()
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
