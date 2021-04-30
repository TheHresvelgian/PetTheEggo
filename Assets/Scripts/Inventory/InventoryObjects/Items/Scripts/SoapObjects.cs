using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Soap Object", menuName = "Inventory System/Items/Soap")]
public class SoapObjects : ItemObjects
{
    public int CleanValue;
    public void Awake()
    {
        type = ItemType.Soap;
    }
}
