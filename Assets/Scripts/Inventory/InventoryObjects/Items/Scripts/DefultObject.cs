using UnityEngine;

namespace Inventory.InventoryObjects
{
    [CreateAssetMenu(fileName = "New Defult Object", menuName = "Inventory System/Items/Defult")]

    public class DefultObject : ItemObjects
    {
        public void Awake()
        {
            type = ItemType.Defult;
        }
    }
}
