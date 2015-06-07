using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject layoutParent;
    [SerializeField] private GameObject itemUIPrefab;

    private void Awake() {

    }

    private void Start() {
        Messenger.AddListener<Item>("ItemAddedToInventory", OnItemAddedToInventory);
    }

    private void Update() {

    }

    private void OnItemAddedToInventory(Item item) {
        GameObject newItemUI = Instantiate(itemUIPrefab);
        newItemUI.GetComponent<Image>().sprite = item.itemImage;
        newItemUI.name = item.itemName;

        newItemUI.transform.SetParent(layoutParent.transform, false);
    }
}
