using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Item
{
    public Item(string itemName, Sprite itemImage) {
        this.itemName = itemName;
        this.itemImage = itemImage;
    }

    public string itemName;
    public Sprite itemImage;
}
