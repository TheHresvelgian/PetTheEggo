using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShopGenerator : MonoBehaviour
{
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private InventoryObject ShopInv;
    private List<ItemObjects> _itemObjectsList;
    [SerializeField] public GameObject children;
    [SerializeField] private List<Transform> grandChildren;
    private GameObject tobedeleated;
    private GameObject deleat;
    private int numb;

    
    public void GenerateSlot(ItemObjects category)
    {
        grandChildren.Clear();
        numb = 0;
        children.GetComponent<Animator>().SetBool("Exit", true);
        deleat = tobedeleated;
        tobedeleated = children;
        children = Instantiate(itemSlot, Vector3.zero, Quaternion.Euler(0,0,0), transform);
        StartCoroutine("EnterSlot", category);
    }

    private IEnumerator EnterSlot(ItemObjects category)
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < children.transform.childCount; i++) grandChildren.Add(children.transform.GetChild(i));

        for (int i = 0; i < ShopInv.Container.Count; i++)
        {
            if (ShopInv.Container[i].item.type.Equals(category.type))
            {
                grandChildren[numb].GetComponent<ShopSlot>().selectedItem = ShopInv.Container[i].item;
                grandChildren[numb].GetComponent<ShopSlot>().amount = ShopInv.Container[i].amount;
                numb++;
                if(numb >= 6) break;
            }
        }
        Destroy(deleat);
    }

}
