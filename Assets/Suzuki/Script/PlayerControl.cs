using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 3f;
    public GameObject nutPrefab; // �؂̎��̃v���t�@�u
    public Transform throwPoint; // �؂̎��𓊂���ʒu
    public float throwForce = 5f; // �؂̎��𓊂����
    public float pickupRange = 2f; // �؂̎����E���͈�
    public bool isHoldingCarrot = true; // �ŏ��͂ɂ񂶂�������Ă�����

    public int carrots = 0;

    private int nutCount = 0; // �v���C���[�������Ă���؂̎��̐�
    public Rabbit rabbit; // �������ւ̎Q�Ƃ�ǉ�
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        carrots = 5;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        // �E�������i���̓��̓L�[�FE�j
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �����ɏE������������
            PickupNut();
          


        }

        // �����鏈���i���̓��̓L�[�FSpace�j
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowNut();
        }
        Carrpts();
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
}


