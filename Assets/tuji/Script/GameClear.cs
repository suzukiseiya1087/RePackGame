using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeUI.m_countHour10==2&&TimeUI.m_countHour1==1)
        {
            //Ç»ÇÒÇ©ââèo

            SceneManager.LoadScene("Result");
        }
    }
}
