using UnityEngine;
using System.Collections;

public class KeyItem : Item
{
    public KeyItemType keyItemType;

    public KeyItem(string name, KeyItemType keyItemType, ItemClass iconType) : base(name, ItemType.KeyItem, iconType)
    {
        this.keyItemType = keyItemType;
    }

    public enum KeyItemType
    {
        None,
        NormalKey
    }
}
