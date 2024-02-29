using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���؂�ւ��֐�(�{�^�����̎��Ɋ֐��Ăяo���Ă�)
/// ����F�җI��
/// </summary>
public class SceneChanger : MonoBehaviour
{
    
    public void ToResult()
    {
        SceneManager.LoadScene("Result");
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ToPlay()
    {
        SceneManager.LoadScene("Nagadomo");
    }
    public void ToStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void EndGame()
    {
        Application.Quit(); 
    }
}