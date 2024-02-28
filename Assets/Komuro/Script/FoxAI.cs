using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// �T�v�F�ς̓������Ǘ�����X�N���v�g
// �쐬�ҁF����

public class FoxAI : MonoBehaviour
{
    // �ς̍��W
    private Vector2 m_position;
    // �؂̎��ɂЂ������Ă��邩
    private bool m_targetNuts;
    // �E�T�M�ɂЂ������Ă��邩
    private bool m_targetRabbit;
    // �ǂ������Ă�����̂̍��W
    private Transform m_target;
    // �^�[�Q�b�g�ɒǂ��������ǂ���
    private bool m_targetGet;
    // �X�|�[�����
    private SpawnFox _spawnFox;
    // �^�[�Q�b�g�ɒǂ�������̌o�ߎ���

    // �ς̓������x
    [SerializeField] Vector2 m_speed;
    private Vector2 m_velosity;

    // ����
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;

    // Start is called before the first frame update
    public void Start()
    {
        m_position = transform.position;
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        m_velosity = m_speed;
        m_beforTime = 10;
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // �^�[�Q�b�g�ɂЂ������Ă���Ƃ��Ɏ��s
        if(m_target != null && m_targetGet == false)
        {
            /*�@�^�[�Q�b�g��ǂ�������@*/
            // ���ݒn���猩���^�[�Q�b�g�̕���

            // ���ݒn����^�[�Q�b�g�ւ̍ŒZ�����i�o�H�T���H�j

            // �^�[�Q�b�g��ǂ�

        }
        if(m_target == null)
        {
            m_targetGet = false;
        }

        // �����ǂ������Ă��Ȃ��Ƃ����R�s��
        // ��莞�Ԃ��Ƃɔ���(3�b)
        int Time = (int)m_foxTime.elapsedTime;
        if(Time - m_beforTime == 3)
        {  
            // �������������߂�
            MoveFox();
            m_beforTime = Time;
        }

        // �ς𓮂���
        m_position += m_speed;
        transform.position = m_position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �؂̎����R���C�_�[���ɓ�������؂̎��̍��W������i�E�T�M���؂̎��D��j
        if (collision.gameObject.CompareTag("Nuts"))
        {
            // �؂̎��ɂЂ������Ă��邩�ǂ���
            m_targetNuts = true;
            m_target = collision.gameObject.transform;
        }
        // �E�T�M���߂��ɂ���Ƃ��E�T�M�̍��W������i��Q�����悯�āj
        else if (collision.gameObject.CompareTag("Rabbit") && m_targetNuts == false)
        {
            m_targetRabbit = true;
            m_target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �؂̎����R���C�_�[������o����؂̎��̍��W���󂯎��i�E�T�M���؂̎��D��j
        if (collision.gameObject.CompareTag("Nuts"))
        {
            // �؂̎��ɂЂ������Ă��邩�ǂ���
            m_targetNuts = true;
            m_target = collision.gameObject.transform;
        }
        // �E�T�M���߂��ɂ���Ƃ��E�T�M�̍��W���󂯎��i��Q�����悯�āj
        else if (collision.gameObject.CompareTag("Rabbit") && m_targetNuts == false)
        {
            m_targetRabbit = true;
            m_target = collision.gameObject.transform;
        }
    }

    // �^�[�Q�b�g�ƐڐG���Ă���Ƃ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �^�[�Q�b�g�ɒǂ�����
        m_targetGet = true;
        // �O�b�ԃ^�[�Q�b�g�̍��W�Œ�~

        // ���ׂďI�������^�[�Q�b�g���f���[�g�i�������́j
        m_target = null; 
        m_targetNuts = false; 
        m_targetRabbit = false;
        
    }

    private void MoveFox()
    {
        int direction = Random.Range(0, 5);
        // �X�s�[�h���v���X�ɂ���
        m_speed = m_velosity;
        switch (direction)
        {
            case 0:     // �E
                m_speed.x *= 1;
                m_speed.y = 0;
                return;
            case 1:     // ��
                m_speed.x *= -1;
                m_speed.y = 0;
                return;
            case 2:     // ��
                m_speed.y *= 1;
                m_speed.x = 0;
                return;
            case 3:     // ��
                m_speed.y *= -1;
                m_speed.x = 0;
                return;
            case 4:     // ���̏�Œ�~
                m_speed = Vector2.zero;
                return;

        }
    }
}
