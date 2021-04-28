using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.InventoryObjects
{
    [CreateAssetMenu(fileName = "New Egg Object", menuName = "Inventory System/Items/Egg")]

    public class EggObject : ItemObjects
    {
        public void Awake()
        {
            type = ItemType.Egg;
        }
    }
}
