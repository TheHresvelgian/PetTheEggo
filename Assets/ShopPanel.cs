using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject ShopGen;
    private void Start()
    {
        ShopGen.GetComponent<ShopGenerator>().children = gameObject;
    }
}
