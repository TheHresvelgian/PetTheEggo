using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Inventory.InventoryObjects;
using NUnit.Framework.Internal.Execution;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class NumbSelect : MonoBehaviour
{
    [SerializeField] public InventoryObject playerInv;
    [SerializeField] private InventoryObject ShopInv;
    [SerializeField] public ItemObjects item;
    private int num = 1;
    public int maxAmount = 4;
    [SerializeField] private List<GameObject> arrows;
    private bool hasMon;
    private int totalCost;
    private TextMeshProUGUI numbText;
    private TextMeshProUGUI descriptionText;
    private Vector3 itemPos;
    [SerializeField] private string textCost;
    public Vector3 pos;
    private GameObject namePanel;

    private void Start()
    {
        
        transform.parent.GetChild(5).GetComponent<ItemImageScript>().Startup(item.sprite, pos);
        descriptionText = transform.parent.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionText.text = item.description;
        if (maxAmount == 1 && hasMon)
        {
            foreach (var arrow in arrows) Destroy(arrow);
            return;
        }
        numbText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        UpdateArrows();
        transform.GetComponent<Animator>().SetBool("Open", true);
    }
    public void Up()
    {
        if (num >= maxAmount || playerInv.Container[0].amount <= totalCost + item.cost - 1) return;
        num++;
        UpdateArrows();
    }
    public void Down()
    {
        if (num == 1) return;
        num--;
        UpdateArrows();
    }

    private void UpdateArrows()
    {
        totalCost = item.cost * num;
        hasMon = playerInv.Container[0].amount >= totalCost;
        
        if (num <= 1) arrows[0].GetComponent<Image>().color = Color.gray;
        else arrows[0].GetComponent<Image>().color = Color.white;
        
        if(num >= maxAmount || playerInv.Container[0].amount <= totalCost + item.cost - 1) arrows[1].GetComponent<Image>().color = Color.gray;
        else arrows[1].GetComponent<Image>().color = Color.white;
        numbText.text = "" + num;
        transform.parent.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = textCost + totalCost + " $";
    }

    public void Accept()
    {
        playerInv.Container[0].amount -= totalCost;
        playerInv.AddItem(item, num);
        if (maxAmount == 1)
        {
            namePanel = GameObject.FindGameObjectWithTag("NamePanel").transform.GetChild(0).gameObject;
            ShopInv.AddItem(item, -1);
            namePanel.SetActive(true);
            namePanel.GetComponent<NameSelectScript>().Item = item;
        }
    }
    

    private void Update()
    {
        print(playerInv.Container[0].amount + "This is mha money");
        print(totalCost + "This is what it cost");
    }
}
