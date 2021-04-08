using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject managerObject;
    private InventoryUIManager _manager;
    [SerializeField] private GameObject _canvasObject;
    private Canvas _canvas;
    private Material _material;
    [SerializeField] private int myNumber;
    private void Start()
    {
        _manager = managerObject.GetComponent<InventoryUIManager>();
        _material = GetComponent<Material>();
        _canvas = _canvasObject.GetComponent<Canvas>();
    }

    private void Update()
    {
        //if (_manager.curentMenu == myNumber) _canvas.sortingOrder = 0;
        //if (_manager.curentMenu == myNumber) 
    }
}
