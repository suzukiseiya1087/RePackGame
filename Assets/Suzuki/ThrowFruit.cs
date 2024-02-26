using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruit : MonoBehaviour
{
    public Transform throwPoint; // ������ʒu
    public GameObject fruitPrefab; // �؂̎���Prefab
    public float throwForce = 10f; // �������

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1�̓f�t�H���g�Ń}�E�X�̍��N���b�N�܂���Ctrl�L�[
        {
            Throw();
        }
    }

    void Throw()
    {
        // �؂̎��̃C���X�^���X���쐬
        GameObject fruit = Instantiate(fruitPrefab, throwPoint.position, throwPoint.rotation);
        // �؂̎��ɗ͂������ē�����
        fruit.GetComponent<Rigidbody2D>().AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }
}