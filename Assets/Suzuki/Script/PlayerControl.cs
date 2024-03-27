using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum PlayerState
    {
        Hand, // 素手
        Carrot, // にんじんを持っている
        Nut // 木の実を持っている
    }
    public GameObject fencePrefab; // 柵のプレファブ
    private GameObject currentFence; // 現在の柵のインスタンスを追跡
    public float fenceToggleDistance = 1.2f; // 柵を開閉できる距離
    public PlayerState currentState = PlayerState.Hand;
   [SerializeField] public float Speed = 3f;
    public GameObject nutPrefab; // 木の実のプレファブ
    public Transform throwPoint; // 木の実を投げる位置
    public float throwForce = 5f; // 木の実を投げる力
    public float pickupRange = 2f; // 木の実を拾う範囲

   [SerializeField] public static int carrotCount = 10; // 最初は5本のにんじんを持っている

    public GameObject carrotPrefab; // にんじんのプレファブ

    public List<GameObject> carrots = new List<GameObject>(); // にんじんのGameObjectリスト

    public CarrotCounter carrotCounter;
    private int nutCount = 0; // プレイヤーが持っている木の実の数

    public List<GameObject> carrotsVisuals = new List<GameObject>();
  
    RabbitAI rabbitAI;
    StartCountDown StartCountDown;
    // Start is called before the first frame update
    void Start()
    {

        currentState = PlayerState.Hand;
        UpdateCarrotVisibility(); // スタート時ににんじんの可視状態を更新
    }

    // Update is called once per frame
    void Update()
    {

        if (StartCountDown.m_moveFlag == false)
        {
            return;
        }

        Move();
        // 拾う処理（仮の入力キー：E）
        // 左クリックで木の実を落とす


        if (Input.GetMouseButton(0))
        {
            // ここに拾う処理を実装
            PickupNut();



        }

        // 投げる処理（仮の入力キー：Space）
        if (Input.GetMouseButtonDown(1))
        {
            DropNut();
            ThrowNut();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (currentState)
            {
                case PlayerState.Hand:
                    currentState = PlayerState.Carrot;
                    break;
                case PlayerState.Carrot:
                    currentState = (nutCount > 0) ? PlayerState.Nut : PlayerState.Hand;
                    break;
                case PlayerState.Nut:
                    currentState = PlayerState.Hand;
                    break;
            }
            Debug.Log($"Current State: {currentState}");
            UpdateCarrotVisibility(); // 状態変更時ににんじんの可視状態を更新
        }
        // 柵を開閉する処理
        if (Input.GetMouseButtonDown(0)) // Fキーを開閉のトリガーとする
        {
            ToggleFence();
        }
    }
    void PickupNut()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Nut"))
            {
                // 木の実を消去し、nutCountを増やす
                Destroy(collider.gameObject);
                nutCount++; // 拾った木の実の数を増やす
                break; // 最も近い一つを拾ったらループを抜ける
            }
        }
    }

    void ThrowNut()
    {
        if (nutCount > 0) // 木の実を持っている確認
        {
            GameObject nut = Instantiate(nutPrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody2D rb = nut.GetComponent<Rigidbody2D>();
            rb.AddForce(throwPoint.right * throwForce, ForceMode2D.Impulse);
            nutCount--; // 投げた木の実の数を減らす

            // プレイヤーと木の実の衝突を無視
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D nutCollider = nut.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(playerCollider, nutCollider);
        }
    }
    void Move()
    {
        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.y += Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= Speed;
        }
        transform.position = position;
    }


    void ToggleFence()
    {
        // プレイヤーと柵のプレファブ生成位置との距離を計算
        float distanceToFence = Vector3.Distance(transform.position, fencePrefab.transform.position);

        // 柵が現在存在しない、かつプレイヤーが柵の近くにいる場合、柵を生成
        if (currentFence == null && distanceToFence <= fenceToggleDistance)
        {
            currentFence = Instantiate(fencePrefab, transform.position + (transform.forward * 1f), Quaternion.identity);
        }
        // 柵が存在し、プレイヤーが柵の近くにいる場合、柵を削除
        else if (currentFence != null && distanceToFence <= fenceToggleDistance)
        {
            Destroy(currentFence);
        }
    }
    void DropNut()
    {
        if (nutCount > 0) // 木の実を持っているか確認
        {
            // プレイヤーの位置に木の実を生成
            GameObject nut = Instantiate(nutPrefab, transform.position, Quaternion.identity);
            nutCount--; // 落とした木の実の数を減らす

            // プレイヤーと木の実の衝突を無視（必要に応じて）
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D nutCollider = nut.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(playerCollider, nutCollider);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Rabbit")) // ウサギとの衝突をチェック
        {
            if (currentState == PlayerState.Hand) // 素手の状態であるかチェック
            {
                // ウサギをなでる処理
                Debug.Log("ウサギをなでました。"); // コンソールにメッセージを表示
            }
            else if (currentState == PlayerState.Carrot) // にんじんを持っている状態
            {
                // ウサギとのトリガーイベントを処理
                ConsumeCarrot();
                
            }
            // 必要に応じて、他の状態に対する処理をここに追加...
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Rabbit")) // ウサギとの衝突をチェック
    //    {
    //        if (currentState == PlayerState.Hand) // 素手の状態であるかチェック
    //        {
    //            // ウサギをなでる処理
    //            Debug.Log("ウサギをなでました。"); // コンソールにメッセージを表示
    //        }
    //        else if (currentState == PlayerState.Carrot) // にんじんを持っている状態
    //        {
    //            // ウサギとのトリガーイベントを処理
    //            ConsumeCarrot();
    //        }
    //        // 必要に応じて、他の状態に対する処理をここに追加...
    //        //    }
    //    }
    //}
    void ConsumeCarrot()
    {
       
        if (currentState == PlayerState.Carrot && carrotCount > 0)
        {
            carrotCount--; // にんじんの数を減らす
            RabbitAI.m_natuki += 1;
            Debug.Log("にんじんを1本消費しました。残りのにんじんの数: " + carrotCount);
            
            currentState = PlayerState.Hand;
            
            UpdateCarrotVisibility(); // にんじんを消費するたびに可視状態を更新
            Debug.Log($"Current State: {currentState}");
            if (carrotCount == 0)
            {
                Debug.Log("にんじんがもうありません！");
            }
        }
    }

    // プレイヤーがにんじんを持っているかどうかを判定するメソッド
    public bool IsHoldingCarrot()
    {
        return carrotCount > 0; // にんじんの数が0より大きければ、プレイヤーはにんじんを持っている
    }
    void UpdateCarrotVisibility()
    {
        bool shouldShowCarrots = currentState == PlayerState.Carrot && carrotCount > 0;
        foreach (var carrot in carrots)
        {
            carrot.SetActive(shouldShowCarrots);
        }
    }
}



