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
    public float Speed = 3f;
    public GameObject nutPrefab; // 木の実のプレファブ
    public Transform throwPoint; // 木の実を投げる位置
    public float throwForce = 5f; // 木の実を投げる力
    public float pickupRange = 2f; // 木の実を拾う範囲
    public bool isHoldingCarrot = true; // 最初はにんじんを持っている状態

    public int carrots = 0;

    private int nutCount = 0; // プレイヤーが持っている木の実の数
    public Rabbit rabbit; // うさぎへの参照を追加
   
    // Start is called before the first frame update
    void Start()
    {
        carrots = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Carrpts();
        // Tabキーでの状態切り替え
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (currentState)
            {
                case PlayerState.Hand:
                    currentState = (carrots > 0) ? PlayerState.Carrot : (nutCount > 0 ? PlayerState.Nut : PlayerState.Hand);
                    break;
                case PlayerState.Carrot:
                    currentState = (nutCount > 0) ? PlayerState.Nut : PlayerState.Hand;
                    break;
                case PlayerState.Nut:
                    currentState = PlayerState.Hand;
                    break;
            }
            Debug.Log($"Current State: {currentState}");
        }
        // 柵を開閉する処理
        if (Input.GetKeyDown(KeyCode.F)) // Fキーを開閉のトリガーとする
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
    // うさぎににんじんを渡すメソッド
    public void GiveCarrotToRabbit(Rabbit rabbit)
    {
        if (carrots > 0)
        {
            carrots--; // にんじんを1本減らす
            //rabbit.EatCarrot(); // うさぎににんじんを食べさせる
            Debug.Log("Carrots: " + carrots); // 現在のにんじんの数をログに出力
        }
        else
        {
            Debug.Log("No more carrots to give.");
        }
    }
    void Carrpts()
    {
        // 素手とにんじんを持っている状態の切り替え
        if (Input.GetKeyDown(KeyCode.C))
        {
            isHoldingCarrot = !isHoldingCarrot; // 状態を切り替える
            Debug.Log($"Is holding carrot: {isHoldingCarrot}");
        }

        // "E"キーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.E))
        {
            // にんじんを持っているかつにんじんがある場合はうさぎににんじんを渡す
            if (isHoldingCarrot && carrots > 0)
            {
                GiveCarrotToRabbit(rabbit);
            }
            else if (!isHoldingCarrot) // にんじんを持っていない場合はうさぎをなでる
            {
                //rabbit.PetRabbit();
            }
        }
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
}


