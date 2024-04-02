using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    private GameObject m_player;
    private Vector3 m_position;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        m_position = m_player.transform.position;
        m_position.z = -10;
        this.transform.position = m_position;
    }
}
