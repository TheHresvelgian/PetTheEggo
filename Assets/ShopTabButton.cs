using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ShopTabButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject ShopController;
    [SerializeField] private ItemObjects searchItem;
    public void OnPointerDown(PointerEventData eventData)
    {
        ShopController.GetComponent<ShopGenerator>().GenerateSlot(searchItem);
    }
}
