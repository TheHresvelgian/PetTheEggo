using System.Collections;
using System.Collections.Generic;
using DataContainers;
using UnityEngine;

namespace Inventory.InventoryObjects
{
    [CreateAssetMenu(fileName = "New Egg Object", menuName = "Inventory System/Items/Egg")]
    
    public class EggObject : ItemObjects
    {
        public PetScrubBase PetScrubBase;
        public void Awake()
        {
            type = ItemType.Egg;
        }
    }
}
