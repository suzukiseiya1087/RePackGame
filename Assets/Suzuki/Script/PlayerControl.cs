using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum PlayerState
    {
        Hand, // �f��
        Carrot, // �ɂ񂶂�������Ă���
        Nut // �؂̎��������Ă���
    }
    public GameObject fencePrefab; // ��̃v���t�@�u
    private GameObject currentFence; // ���݂̍�̃C���X�^���X��ǐ�
    public float fenceToggleDistance = 1.2f; // ����J�ł��鋗��
    public PlayerState currentState = PlayerState.Hand;
   [SerializeField] public float Speed = 3f;
    public GameObject nutPrefab; // �؂̎��̃v���t�@�u
    public Transform throwPoint; // �؂̎��𓊂���ʒu
    public float throwForce = 5f; // �؂̎��𓊂����
    public float pickupRange = 2f; // �؂̎����E���͈�

   [SerializeField] public static int carrotCount = 10; // �ŏ���5�{�̂ɂ񂶂�������Ă���

    public GameObject carrotPrefab; // �ɂ񂶂�̃v���t�@�u

    public List<GameObject> carrots = new List<GameObject>(); // �ɂ񂶂��GameObject���X�g

    public CarrotCounter carrotCounter;
    private int nutCount = 0; // �v���C���[�������Ă���؂̎��̐�

    public List<GameObject> carrotsVisuals = new List<GameObject>();
  
    RabbitAI rabbitAI;
    StartCountDown StartCountDown;
    // Start is called before the first frame update
    void Start()
    {

        currentState = PlayerState.Hand;
        UpdateCarrotVisibility(); // �X�^�[�g���ɂɂ񂶂�̉���Ԃ��X�V
    }

    // Update is called once per frame
    void Update()
    {

        if (StartCountDown.m_moveFlag == false)
        {
            return;
        }

        Move();
        // �E�������i���̓��̓L�[�FE�j
        // ���N���b�N�Ŗ؂̎��𗎂Ƃ�


        if (Input.GetMouseButton(0))
        {
            // �����ɏE������������
            PickupNut();



        }

        // �����鏈���i���̓��̓L�[�FSpace�j
        if (Input.GetMouseButtonDown(1))
        {
            DropNut();
            ThrowNut();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (currentState)
            {
                case PlayerState.Hand:
                    currentState = PlayerState.Carrot;
                    break;
                case PlayerState.Carrot:
                    currentState = (nutCount > 0) ? PlayerState.Nut : PlayerState.Hand;
                    break;
                case PlayerState.Nut:
                    currentState = PlayerState.Hand;
                    break;
            }
            Debug.Log($"Current State: {currentState}");
            UpdateCarrotVisibility(); // ��ԕύX���ɂɂ񂶂�̉���Ԃ��X�V
        }
        // ����J���鏈��
        if (Input.GetMouseButtonDown(0)) // F�L�[���J�̃g���K�[�Ƃ���
        {
            ToggleFence();
        }
    }
    void PickupNut()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Nut"))
            {
                // �؂̎����������AnutCount�𑝂₷
                Destroy(collider.gameObject);
                nutCount++; // �E�����؂̎��̐��𑝂₷
                break; // �ł��߂�����E�����烋�[�v�𔲂���
            }
        }
    }

    void ThrowNut()
    {
        if (nutCount > 0) // �؂̎��������Ă���m�F
        {
            GameObject nut = Instantiate(nutPrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody2D rb = nut.GetComponent<Rigidbody2D>();
            rb.AddForce(throwPoint.right * throwForce, ForceMode2D.Impulse);
            nutCount--; // �������؂̎��̐������炷

            // �v���C���[�Ɩ؂̎��̏Փ˂𖳎�
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D nutCollider = nut.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(playerCollider, nutCollider);
        }
    }
    void Move()
    {
        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.y += Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= Speed;
        }
        transform.position = position;
    }


    void ToggleFence()
    {
        // �v���C���[�ƍ�̃v���t�@�u�����ʒu�Ƃ̋������v�Z
        float distanceToFence = Vector3.Distance(transform.position, fencePrefab.transform.position);

        // �򂪌��ݑ��݂��Ȃ��A���v���C���[����̋߂��ɂ���ꍇ�A��𐶐�
        if (currentFence == null && distanceToFence <= fenceToggleDistance)
        {
            currentFence = Instantiate(fencePrefab, transform.position + (transform.forward * 1f), Quaternion.identity);
        }
        // �򂪑��݂��A�v���C���[����̋߂��ɂ���ꍇ�A����폜
        else if (currentFence != null && distanceToFence <= fenceToggleDistance)
        {
            Destroy(currentFence);
        }
    }
    void DropNut()
    {
        if (nutCount > 0) // �؂̎��������Ă��邩�m�F
        {
            // �v���C���[�̈ʒu�ɖ؂̎��𐶐�
            GameObject nut = Instantiate(nutPrefab, transform.position, Quaternion.identity);
            nutCount--; // ���Ƃ����؂̎��̐������炷

            // �v���C���[�Ɩ؂̎��̏Փ˂𖳎��i�K�v�ɉ����āj
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D nutCollider = nut.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(playerCollider, nutCollider);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Rabbit")) // �E�T�M�Ƃ̏Փ˂��`�F�b�N
        {
            if (currentState == PlayerState.Hand) // �f��̏�Ԃł��邩�`�F�b�N
            {
                // �E�T�M���Ȃł鏈��
                Debug.Log("�E�T�M���Ȃł܂����B"); // �R���\�[���Ƀ��b�Z�[�W��\��
            }
            else if (currentState == PlayerState.Carrot) // �ɂ񂶂�������Ă�����
            {
                // �E�T�M�Ƃ̃g���K�[�C�x���g������
                ConsumeCarrot();
                
            }
            // �K�v�ɉ����āA���̏�Ԃɑ΂��鏈���������ɒǉ�...
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Rabbit")) // �E�T�M�Ƃ̏Փ˂��`�F�b�N
    //    {
    //        if (currentState == PlayerState.Hand) // �f��̏�Ԃł��邩�`�F�b�N
    //        {
    //            // �E�T�M���Ȃł鏈��
    //            Debug.Log("�E�T�M���Ȃł܂����B"); // �R���\�[���Ƀ��b�Z�[�W��\��
    //        }
    //        else if (currentState == PlayerState.Carrot) // �ɂ񂶂�������Ă�����
    //        {
    //            // �E�T�M�Ƃ̃g���K�[�C�x���g������
    //            ConsumeCarrot();
    //        }
    //        // �K�v�ɉ����āA���̏�Ԃɑ΂��鏈���������ɒǉ�...
    //        //    }
    //    }
    //}
    void ConsumeCarrot()
    {
       
        if (currentState == PlayerState.Carrot && carrotCount > 0)
        {
            carrotCount--; // �ɂ񂶂�̐������炷
            RabbitAI.m_natuki += 1;
            Debug.Log("�ɂ񂶂��1�{����܂����B�c��̂ɂ񂶂�̐�: " + carrotCount);
            
            currentState = PlayerState.Hand;
            
            UpdateCarrotVisibility(); // �ɂ񂶂������邽�тɉ���Ԃ��X�V
            Debug.Log($"Current State: {currentState}");
            if (carrotCount == 0)
            {
                Debug.Log("�ɂ񂶂񂪂�������܂���I");
            }
        }
    }

    // �v���C���[���ɂ񂶂�������Ă��邩�ǂ����𔻒肷�郁�\�b�h
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // �ɂ񂶂�̐���0���傫����΁A�v���C���[�͂ɂ񂶂�������Ă���
    }
    void UpdateCarrotVisibility()
    {
        bool shouldShowCarrots = currentState == PlayerState.Carrot && carrotCount > 0;
        foreach (var carrot in carrots)
        {
            carrot.SetActive(shouldShowCarrots);
        }
    }
}



