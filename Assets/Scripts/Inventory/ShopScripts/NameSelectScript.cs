using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataContainers;
using Inventory.InventoryObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameSelectScript : MonoBehaviour
{
    private TMP_InputField InputField;
    private EggObject Egg;
    public ItemObjects Item;
    private PetScrubBase PetScrubBase;
    [SerializeField] private List<EggObject> eggList;

    private void OnEnable() => StartCoroutine("Enable");
    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (var eggObject in eggList)
        {
            if (eggObject.name == Item.name)
            {
                Egg = eggObject;
                break;
            }
        }
        if(Egg == null) StopCoroutine("Enable");
        PetScrubBase = Egg.PetScrubBase;
        foreach (Transform child in transform)
        {
            if (child.name == "EggImage") child.GetComponent<Image>().sprite = Egg.sprite;
            if (child.CompareTag("InputField")) InputField = child.GetComponent<TMP_InputField>();
        }
    }

    public void Accept()
    {
        PetScrubBase.petName = InputField.text;
        InputField.text = "";
    }
}
