using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    // 経過時間を格納する
    public float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を格納
        elapsedTime = Time.time;
        Debug.Log(elapsedTime);
    }
}
