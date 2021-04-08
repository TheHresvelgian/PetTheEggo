using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Soap,
        Apple,
        Meat,
        Sponge,
    }

    public ItemType itemType;
    public int amount;
}
