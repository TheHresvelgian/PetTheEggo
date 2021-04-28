using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.InventoryObjects
{
    [CreateAssetMenu(fileName = "New Null Object", menuName = "Inventory System/Items/Null")]

    public class NullObject : ItemObjects
    {
        public void Awake()
        {
            type = ItemType.Null;
        }
    }
}
