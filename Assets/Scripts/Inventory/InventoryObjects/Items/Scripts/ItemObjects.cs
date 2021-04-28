using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Soap,
    Defult,
    Null,
    Egg
}
public abstract class ItemObjects : ScriptableObject
{
    public Sprite sprite;
    public int cost;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
