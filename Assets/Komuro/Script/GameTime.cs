using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    // Œo‰ßŽžŠÔ‚ðŠi”[‚·‚é
    public float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Œo‰ßŽžŠÔ‚ðŠi”[
        elapsedTime = Time.time;
        Debug.Log(elapsedTime);
    }
}
