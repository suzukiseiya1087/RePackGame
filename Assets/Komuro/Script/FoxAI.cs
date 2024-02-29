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
    private int m_targetGetTime;

    // �ς̓������x
    [SerializeField] Vector2 m_speed;
    private Vector2 m_velosity;

    // ����
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;

    // Start is called before the first frame update
    void Start()
    {
        m_position = transform.position;
        m_targetNuts = false;
        m_targetRabbit = false;
        m_targetGet = false;
        m_velosity = m_speed;
        m_beforTime = 10;
        m_targetGetTime = 0;
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // �^�[�Q�b�g�ɂЂ������Ă���Ƃ��Ɏ��s
        if(m_target != null && m_targetGet == false)
        {
            // �X�s�[�h�������Ă��邩
            if(m_speed.x == 0 && m_speed.y == 0)
            {
                m_speed = m_velosity;
            }

            /*�@�^�[�Q�b�g��ǂ�������@*/
            // ���ݒn���猩���^�[�Q�b�g�̕���
            Vector2 direction;
            direction.x = m_target.position.x - transform.position.x;
            direction.y = m_target.position.y - transform.position.y;

            /*-----------------------------------------------------------------------------
             *
             *
             *          �X�s�[�h���O�ɂȂ錴���ȉ��̃v���O�����ɂ���
             *
             *
             ------------------------------------------------------------------------------*/
            // �E
            if (direction.x < 0)
            {
                m_speed.x = m_velosity.x;
            }
            // ��
            else if(direction.x > 0)
            {
                m_speed.x = -m_velosity.x;
            }
            // ��
            if(direction.y < 0)
            {
                m_speed.y = m_velosity.y;
            }
            // ��
            else if (direction.y > 0)
            {
                m_speed.y = -m_velosity.y;
            }


            // �^�[�Q�b�g��ǂ�
            m_speed *= 2;

        }
        if(m_target == null)
        {
            m_targetGet = false;
        }
        // �^�[�Q�b�g��߂܂����Ƃ��Ɏ��s
        if(m_targetGet == true && m_targetGetTime == 0)
        {
            m_targetGetTime = (int)m_foxTime.elapsedTime;
        }
        // �R�b�������瓮���n�߂�
        if((int)m_foxTime.elapsedTime - m_targetGetTime == 3)
        {
            m_targetGetTime = 0;
            m_target = null;
            m_targetNuts = false;
            m_targetRabbit = false;
            m_speed = m_velosity;
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
        if (collision.gameObject.CompareTag("Nut"))
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
        if (collision.gameObject.CompareTag("Nut"))
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
        // �؂ƐڐG�����ꍇ
        if(collision.gameObject.CompareTag("Wood"))
        {
            WoodMoveFox(collision);
            return;
        }

        // �^�[�Q�b�g�ɒǂ�����
        m_targetGet = true;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        MoveFox();
    }


    private void MoveFox()
    {
        int direction = Random.Range(0, 5);
        // �X�e�[�W�̒[�߂��ɂ���ꍇ
        

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

    private void WoodMoveFox(Collision2D collision)
    {
        GameObject Wood = collision.gameObject;
        Vector2 WoodPos = Wood.transform.position;
        float lengthx = WoodPos.x - transform.position.x;
        float lengthy = WoodPos.y - transform.position.y;
        int _N;
        if (Mathf.Abs(lengthx) > Mathf.Abs(lengthy))
        {
            _N = 1;
        }
        else
        {
            _N = 0;
        }

        if (_N == 0)
        {
            // �E�ɂ悯��
            if (WoodPos.x < transform.position.x)
            {
                m_speed.x *= 1;
                m_speed.y = 0;
            }
            // ���ɂ悯��}
            if (WoodPos.x < transform.position.x)
            {
                m_speed.x *= -1;
                m_speed.y = 0;
            }
        }
        else if (_N == 1)
        {
            // ��ɂ悯��
            if (WoodPos.y < transform.position.y)
            {
                m_speed.y *= 1;
                m_speed.x = 0;
            }
            // ���ɂ悯��}
            if (WoodPos.y < transform.position.y)
            {
                m_speed.y *= -1;
                m_speed.x = 0;
            }
        }
    }
}
