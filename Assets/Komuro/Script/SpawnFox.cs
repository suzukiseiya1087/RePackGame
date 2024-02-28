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
    // �ς̏o�����W
    public Vector3 _FoxPos;
    // �o��������Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject m_foxPrefab;
    // �o������͈�
    private Transform m_spawnRange;
    // �o�����Ȃ��͈�
    private Transform m_noSpawnRange;
    // �o�ߎ��ԁi���j
    private GameObject m_time;
    private GameTime m_foxTime;

    // Start is called before the first frame update
    void Start()
    {
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // �X�e�[�W���̌ς̐���Max�ȉ���
        if(m_foxCount > MaxFoxCount) { return; }
        // ��莞�Ԃ��o�߂��Ă��邩
        // StartFoxSpawnTime�b�o�ߌ�@x(foxSpawnTime)�b�o�߂��邲�Ƃ�1�C������
        if ( m_foxTime.elapsedTime < StartFoxSpawnTime){return;}
        if ( m_foxTime.elapsedTime / foxSpawnTime < 1){ return; }
        // �o���ʒu�����߂�
        _FoxPos = FoxTransForm();
        // �X�e�[�W��ɏo�����Ă���ς̐�(�v���k)

        // �ς��o��������
        // Fox��prefab���X�e�[�W��ɏo��������
        Instantiate(m_foxPrefab, _FoxPos, m_foxPrefab.transform.rotation);
        m_foxCount += 1;
    }

    // �o��������W�����߂�
    private Vector3 FoxTransForm()
    {
        Vector3 FoxTransFormPos;
        FoxTransFormPos.x = Random.Range( 0, MaxFoxCount );
        FoxTransFormPos.y = Random.Range(0, MaxFoxCount);
        FoxTransFormPos.z = Random.Range(0, MaxFoxCount);

        return FoxTransFormPos;
    }
}
