using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    // �o�ߎ��Ԃ��i�[����
    public float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��i�[
        elapsedTime = Time.time;
        Debug.Log(elapsedTime);
    }
}
