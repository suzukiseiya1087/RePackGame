using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン切り替え関数(ボタン等の時に関数呼び出してね)
/// 制作：辻悠歌
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