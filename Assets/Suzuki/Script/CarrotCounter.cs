using TMPro;
using UnityEngine;

public class CarrotCounter : MonoBehaviour
{
    public TextMeshProUGUI carrotCountText; // UIテキストへの参照
    public int initialCarrotCount = 5; // にんじんの初期個数

    // スタート時にUIテキストを更新
    void Start()
    {
        UpdateCarrotCountUI();
    }

    // にんじんのUIテキストを更新するメソッド
    void UpdateCarrotCountUI()
    {
        carrotCountText.text = "Carrots: " + initialCarrotCount.ToString();
    }

    // にんじんの個数を変更するためのメソッド（例）
    public void AddCarrot()
    {
        initialCarrotCount++;
        UpdateCarrotCountUI();
    }

    public void UseCarrot()
    {
        if (initialCarrotCount > 0)
        {
            initialCarrotCount--; // にんじんの個数を1減らす
            UpdateCarrotCountUI(); // UIテキストを更新
        }
    }
}
