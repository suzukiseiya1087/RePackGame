using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// �T�v�F�ς̓������Ǘ�����X�N���v�g
// �쐬�ҁF����

public class FoxAI : MonoBehaviour
{
    // �ς̍��W
    public Vector3 m_foxPos;
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

    // Start is called before the first frame update
    void Start()
    {
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        //// �������W�ݒ�
        //m_foxPos = _spawnFox._FoxPos;
        //this.gameObject.transform.position = m_foxPos;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�[�Q�b�g�ɂЂ������Ă���Ƃ��Ɏ��s
        if(m_target != null)
        {
            /*�@�^�[�Q�b�g��ǂ�������@*/
            // ���ݒn���猩���^�[�Q�b�g�̕���

            // ���ݒn����^�[�Q�b�g�ւ̍ŒZ�����i�o�H�T���H�j

            // �^�[�Q�b�g��ǂ�

        }
        

        // �����ǂ������Ă��Ȃ��Ƃ����R�s��
        // ��莞�Ԃ��Ƃɔ���
        // �������������߂�

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
        // �O�b�ԃ^�[�Q�b�g�̍��W�Œ�~

        // ���ׂďI�������^�[�Q�b�g���f���[�g�i�������́j

        
    }
}
