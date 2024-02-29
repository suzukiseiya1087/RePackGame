using TMPro;
using UnityEngine;

public class CarrotCounter : MonoBehaviour
{
    public TextMeshProUGUI carrotCountText; // UI�e�L�X�g�ւ̎Q��
    public int initialCarrotCount = 5; // �ɂ񂶂�̏�����

    // �X�^�[�g����UI�e�L�X�g���X�V
    void Start()
    {
        UpdateCarrotCountUI();
    }

    // �ɂ񂶂��UI�e�L�X�g���X�V���郁�\�b�h
    void UpdateCarrotCountUI()
    {
        carrotCountText.text = "Carrots: " + initialCarrotCount.ToString();
    }

    // �ɂ񂶂�̌���ύX���邽�߂̃��\�b�h�i��j
    public void AddCarrot()
    {
        initialCarrotCount++;
        UpdateCarrotCountUI();
    }

    public void UseCarrot()
    {
        if (initialCarrotCount > 0)
        {
            initialCarrotCount--; // �ɂ񂶂�̌���1���炷
            UpdateCarrotCountUI(); // UI�e�L�X�g���X�V
        }
    }
}
