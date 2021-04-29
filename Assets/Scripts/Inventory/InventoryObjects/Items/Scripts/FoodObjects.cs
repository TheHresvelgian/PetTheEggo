using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class FoodObjects : ItemObjects
{
    public int foodValue;
    public void Awake()
    {
        type = ItemType.Food;
    }
}