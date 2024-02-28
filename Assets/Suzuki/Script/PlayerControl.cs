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
    public float Speed = 3f;
    public GameObject nutPrefab; // �؂̎��̃v���t�@�u
    public Transform throwPoint; // �؂̎��𓊂���ʒu
    public float throwForce = 5f; // �؂̎��𓊂����
    public float pickupRange = 2f; // �؂̎����E���͈�
    public bool isHoldingCarrot = true; // �ŏ��͂ɂ񂶂�������Ă�����

    public int carrots = 0;

    private int nutCount = 0; // �v���C���[�������Ă���؂̎��̐�
    public Rabbit rabbit; // �������ւ̎Q�Ƃ�ǉ�
   
    // Start is called before the first frame update
    void Start()
    {
        carrots = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Carrpts();
        // Tab�L�[�ł̏�Ԑ؂�ւ�
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (currentState)
            {
                case PlayerState.Hand:
                    currentState = (carrots > 0) ? PlayerState.Carrot : (nutCount > 0 ? PlayerState.Nut : PlayerState.Hand);
                    break;
                case PlayerState.Carrot:
                    currentState = (nutCount > 0) ? PlayerState.Nut : PlayerState.Hand;
                    break;
                case PlayerState.Nut:
                    currentState = PlayerState.Hand;
                    break;
            }
            Debug.Log($"Current State: {currentState}");
        }
        // ����J���鏈��
        if (Input.GetKeyDown(KeyCode.F)) // F�L�[���J�̃g���K�[�Ƃ���
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
    // �������ɂɂ񂶂��n�����\�b�h
    public void GiveCarrotToRabbit(Rabbit rabbit)
    {
        if (carrots > 0)
        {
            carrots--; // �ɂ񂶂��1�{���炷
            //rabbit.EatCarrot(); // �������ɂɂ񂶂��H�ׂ�����
            Debug.Log("Carrots: " + carrots); // ���݂̂ɂ񂶂�̐������O�ɏo��
        }
        else
        {
            Debug.Log("No more carrots to give.");
        }
    }
    void Carrpts()
    {
        // �f��Ƃɂ񂶂�������Ă����Ԃ̐؂�ւ�
        if (Input.GetKeyDown(KeyCode.C))
        {
            isHoldingCarrot = !isHoldingCarrot; // ��Ԃ�؂�ւ���
            Debug.Log($"Is holding carrot: {isHoldingCarrot}");
        }

        // "E"�L�[�������ꂽ�Ƃ��̏���
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �ɂ񂶂�������Ă��邩�ɂ񂶂񂪂���ꍇ�͂������ɂɂ񂶂��n��
            if (isHoldingCarrot && carrots > 0)
            {
                GiveCarrotToRabbit(rabbit);
            }
            else if (!isHoldingCarrot) // �ɂ񂶂�������Ă��Ȃ��ꍇ�͂��������Ȃł�
            {
                //rabbit.PetRabbit();
            }
        }
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
}


