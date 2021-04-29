using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public ItemObjects selectedItem;
    public int amount;
    [SerializeField] private InventoryObject playerInv;
    private bool canBuy;
    private Image img;
    private bool start;
    [SerializeField] private GameObject AcceptBox;
    private GameObject AB;
    private Canvas[] _canvasList;
    private Canvas _canvas;
    private Button button;

    private void Start() => StartCoroutine("SelfDestroy");
    private IEnumerator SelfDestroy()
    {
        button = GetComponent<Button>();
        yield return new WaitForSeconds(0.11f);
        if (selectedItem == null)
        {
            Destroy(gameObject);
            yield break;
        }
        img = GetComponent<Image>(); 
        img.sprite = selectedItem.sprite;
        if (selectedItem.cost != 999)
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "$" + selectedItem.cost;
        else transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "$∞";
        start = true;
        _canvasList = new Canvas[2];
        _canvasList = FindObjectsOfType<Canvas>();
        _canvas = _canvasList[1];

    }

    private void Update()
    {
        if (!start) return;
        canBuy = playerInv.Container[0].amount >= selectedItem.cost && amount != 0;
        if (canBuy)
        {
            img.color = Color.white;
            button.enabled = true;
        }
        else
        {
            img.color = Color.grey;
            button.enabled = false;
        }
        
    }

    public void ItemPressed()
    {
        if (!canBuy && !start) return;
        AB = Instantiate(AcceptBox, _canvas.transform);
        var Numb = AB.transform.GetChild(0).GetComponent<NumbSelect>();
        Numb.item = selectedItem;
        Numb.pos = GetComponent<RectTransform>().position;
        Numb.maxAmount = amount;


        /*playerInv.Container[0].amount -= selectedItem.cost;
        playerInv.AddItem(selectedItem,1);*/

    }
}
