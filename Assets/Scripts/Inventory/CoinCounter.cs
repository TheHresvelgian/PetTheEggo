using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private InventoryObject inv;
    private Image img;
    private TextMeshProUGUI _text;
    private void Start()
    {
        img = GetComponent<Image>();
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        img.sprite = inv.Container[0].item.sprite;
    }
    private void Update() => _text.text = "" + inv.Container[0].amount;
    
}
