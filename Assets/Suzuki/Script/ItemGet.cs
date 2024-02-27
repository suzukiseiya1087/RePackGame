using UnityEngine;
public class ItemGet : MonoBehaviour
{
    Vector3 Pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pos.x = ItemManager.instance.ItemSlot.transform.position.x;
            Pos.y = ItemManager.instance.ItemSlot.transform.position.y;
            Pos.z = 0;
            transform.position = Pos;
        }
    }
}