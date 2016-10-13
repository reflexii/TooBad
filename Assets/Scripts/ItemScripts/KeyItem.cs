using UnityEngine;
using System.Collections;

public class KeyItem : Item
{
    public KeyItemType keyItemType;

    public KeyItem(string name, KeyItemType keyItemType, Color itemIcon) : base(name, ItemType.KeyItem, itemIcon)
    {
        this.keyItemType = keyItemType;
    }

    public enum KeyItemType
    {
        None,
        NormalKey
    }
}
