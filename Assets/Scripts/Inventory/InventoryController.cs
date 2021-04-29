using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] public GameObject pressControl;
    [SerializeField] private GameObject _inv;
    private List<InventorySlot> Container;
    public List<GameObject> children;
    public List<TextMeshProUGUI> text;
    public List<ItemDrag> ItemDrags;
    private int numb;
    [SerializeField] private ItemObjects itemType;

    private void Start()
    {
        Container = _inv.GetComponent<Invetory>().inventory.Container;
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
            ItemDrags.Add(child.GetChild(1).GetComponent<ItemDrag>());
            text.Add(child.GetChild(2).GetComponent<TextMeshProUGUI>());
        }
    }

    private void OnEnable() => StartCoroutine("Enable");

    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(0.6f);
        GenerateList();
    }

    public void GenerateList()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(true);
        numb = 0;
        foreach (var itemDrag in ItemDrags) itemDrag.ItemObjects = null;
        
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item.type == itemType.type && Container[i].amount >= 1)
            {
                ItemDrags[numb].ItemObjects = Container[i].item;
                if (Container[i].amount >= 2) text[numb].text = "x" + Container[i].amount;
                else text[numb].text = null;
                if (numb >= 5) return;
                numb++;
            }
        }
        
        foreach (var itemDrag in ItemDrags) itemDrag.Startup();
        //for (int i = 0; i < 6-numb; i++) transform.GetChild(5).gameObject.SetActive(false);
    }
}
