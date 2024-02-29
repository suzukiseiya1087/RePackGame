using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �T�v�F�ς��X�|�[�����邩�ǂ����𔻒肷��X�N���v�g
// �쐬�ҁF����

public class SpawnFox : MonoBehaviour
{
    // �ς̍ő�o����
    [SerializeField] int MaxFoxCount;
    // �o�����Ă���ς̐�
    private int m_foxCount;
    // �ς̏o���b���i���b���Ƃɏo�����邩�j
    [SerializeField] float foxSpawnTime;
    // �ς��o�����n�߂鎞��
    [SerializeField] float StartFoxSpawnTime;
    // �ς̏o�����W�̔z��
    [SerializeField] private Vector3[] _FoxPos;
    // �o��������Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject m_foxPrefab;
    // �o������ꏊ
    private Vector3 m_spawnRange;
    // �o�����Ȃ��͈�
    //private Transform m_noSpawnRange;
    // �o�ߎ��ԁi���j
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;
    // Start is called before the first frame update
    void Start()
    {
        m_time = GameObject.Find("Time");
        m_foxTime = m_time.GetComponent<GameTime>();
        m_beforTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int ElapsedTime = (int)m_foxTime.elapsedTime;
        // �O��̎��Ԃƍ���̎��Ԃ������Ȃ珈�����Ȃ�
        if(m_beforTime ==  ElapsedTime) { return; }

        // �X�e�[�W���̌ς̐���Max��葽��
        if (m_foxCount > MaxFoxCount) { return; }
        // ��莞�Ԃ��o�߂��Ă��邩
        // StartFoxSpawnTime�b�o�ߌ�@x(foxSpawnTime)�b�o�߂��邲�Ƃ�1�C������
        if ( ElapsedTime < StartFoxSpawnTime){ return; }
        if ( ElapsedTime % foxSpawnTime != 0){ return; }
        // �o���ʒu�����߂�
        Vector3 Pos = FoxTransForm();

        // �ς��o��������
        // Fox��prefab���X�e�[�W��ɏo��������
        GameObject Fox = Instantiate(m_foxPrefab, Pos, m_foxPrefab.transform.rotation);
        m_foxCount += 1;
        Fox.name = "Fox" + m_foxCount;

        m_beforTime = ElapsedTime;
    }

    // �o��������W�����߂�
    private Vector3 FoxTransForm()
    {
        // �o�����W
        m_spawnRange = _FoxPos[Random.Range(0, _FoxPos.Length)];

        return m_spawnRange;
    }
}
