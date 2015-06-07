using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : Singleton<Inventory>
{
    protected Inventory() {} // Can't use the constructor, singleton only.

    // Order matters, List instead of HashSet.
    // Duplicates allowed but not grouped.
    private List<Item> inventoryItems;

    protected override void Awake() {
        base.Awake();

        inventoryItems = new List<Item>();
    }

    public void AddToInventory(Item item) {
        inventoryItems.Add(item);
        Messenger.Broadcast("ItemAddedToInventory", item);
    }

    public bool HasItem(string itemName) {
        return inventoryItems.Any(item => item.itemName == itemName);
    }
}
