using UnityEngine;
using System.Collections;

public class AddToInventoryHelper : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;

    private void Awake() {
        Inventory.Instance.Wakeup();
    }

    private void Start() {

    }

    private void Update() {

    }

    public void AddToInventory() {
        Inventory.Instance.AddToInventory(new Item(itemName, itemImage));
    }
}
