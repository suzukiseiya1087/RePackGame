using UnityEngine;
public class ItemManager : MonoBehaviour
{
    public GameObject ItemSlot;
    public static ItemManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
}