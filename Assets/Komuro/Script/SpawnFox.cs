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
    // 狐の出現座標
    public Vector3 _FoxPos;
    // 出現させるゲームオブジェクト
    [SerializeField]
    private GameObject m_foxPrefab;
    // 出現する範囲
    private Transform m_spawnRange;
    // 出現しない範囲
    private Transform m_noSpawnRange;
    // 経過時間（仮）
    private GameObject m_time;
    private GameTime m_foxTime;

    // Start is called before the first frame update
    void Start()
    {
        m_time = GameObject.Find("GameTime");
        m_foxTime = m_time.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        // ステージ内の狐の数がMax以下か
        if(m_foxCount > MaxFoxCount) { return; }
        // 一定時間が経過しているか
        // StartFoxSpawnTime秒経過後　x(foxSpawnTime)秒経過するごとに1匹増える
        if ( m_foxTime.elapsedTime < StartFoxSpawnTime){return;}
        if ( m_foxTime.elapsedTime / foxSpawnTime < 1){ return; }
        // 出現位置を決める
        _FoxPos = FoxTransForm();
        // ステージ上に出現している狐の数(要相談)

        // 狐を出現させる
        // Foxのprefabをステージ上に出現させる
        Instantiate(m_foxPrefab, _FoxPos, m_foxPrefab.transform.rotation);
        m_foxCount += 1;
    }

    // 出現する座標を決める
    private Vector3 FoxTransForm()
    {
        Vector3 FoxTransFormPos;
        FoxTransFormPos.x = Random.Range( 0, MaxFoxCount );
        FoxTransFormPos.y = Random.Range(0, MaxFoxCount);
        FoxTransFormPos.z = Random.Range(0, MaxFoxCount);

        return FoxTransFormPos;
    }
}
