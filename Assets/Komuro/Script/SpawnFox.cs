using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 概要：狐がスポーンするかどうかを判定するスクリプト
// 作成者：小室

public class SpawnFox : MonoBehaviour
{
    // 狐の最大出現数
    [SerializeField] int MaxFoxCount;
    // 出現している狐の数
    private int m_foxCount;
    // 狐の出現秒数（何秒ごとに出現するか）
    [SerializeField] float foxSpawnTime;
    // 狐が出現し始める時間
    [SerializeField] float StartFoxSpawnTime;
    // 狐の出現座標の配列
    [SerializeField] private Vector3[] _FoxPos;
    // 出現させるゲームオブジェクト
    [SerializeField]
    private GameObject m_foxPrefab;
    // 出現する場所
    private Vector3 m_spawnRange;
    // 出現しない範囲
    //private Transform m_noSpawnRange;
    // 経過時間（仮）
    private GameObject m_time;
    private GameTime m_foxTime;
    private int m_beforTime;
    // Start is called before the first frame update
    void Start()
    {
        m_time = GameObject.Find("Time");
        m_foxTime = m_time.GetComponent<GameTime>();
        m_beforTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int ElapsedTime = (int)m_foxTime.elapsedTime;
        // 前回の時間と今回の時間が同じなら処理しない
        if(m_beforTime ==  ElapsedTime) { return; }

        // ステージ内の狐の数がMaxより多い
        if (m_foxCount > MaxFoxCount) { return; }
        // 一定時間が経過しているか
        // StartFoxSpawnTime秒経過後　x(foxSpawnTime)秒経過するごとに1匹増える
        if ( ElapsedTime < StartFoxSpawnTime){ return; }
        if ( ElapsedTime % foxSpawnTime != 0){ return; }
        // 出現位置を決める
        Vector3 Pos = FoxTransForm();

        // 狐を出現させる
        // Foxのprefabをステージ上に出現させる
        GameObject Fox = Instantiate(m_foxPrefab, Pos, m_foxPrefab.transform.rotation);
        m_foxCount += 1;
        Fox.name = "Fox" + m_foxCount;

        m_beforTime = ElapsedTime;
    }

    // 出現する座標を決める
    private Vector3 FoxTransForm()
    {
        // 出現座標
        m_spawnRange = _FoxPos[Random.Range(0, _FoxPos.Length)];

        return m_spawnRange;
    }
}
