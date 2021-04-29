using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatureController : MonoBehaviour
{
    public List<GameObject> creatures;
    public List<Animator> anim;
    [SerializeField] private GameObject LivingroomUIButtons;
    [SerializeField] private GameObject UImanager;
    [SerializeField] [Range(0.5f, 5f)] public float swapSpeed = 2f;
    [SerializeField] public GameObject selectedPet;
    private int counter = 0;
    private int selectAnim;
    
    private void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<Animator>() != null) creatures.Add(child.gameObject);
            anim.Add(child.gameObject.GetComponent<Animator>());
            anim[counter].speed = swapSpeed;
            if (counter == 0)
            {
                selectedPet = child.gameObject;
                anim[counter].SetInteger("Position", counter);
                counter++;
            }
            else if (counter == 1)
            {
                anim[counter].SetInteger("Position", counter);
                counter++;
            }
            else if (counter == 2)
            {
                anim[counter].SetInteger("Position", counter);
                counter = 0;
            }
        }
    }
    public void RotateLeft()
    {
        for (int i = 0; i < anim.Count; i++)
        {
            int pos = anim[i].GetInteger("Position");
            if (pos == 2) pos = 0;
            else pos++;
            anim[i].SetInteger("Position", pos);
            if (pos == 0)
            {
                selectedPet = creatures[i];
                selectAnim = i;
            }
        }
    }
    public void RotateRight()
    {
        for (int i = 0; i < anim.Count; i++)
        {
            int pos = anim[i].GetInteger("Position");
            if (pos == 0) pos = 2;
            else pos--;
            anim[i].SetInteger("Position", pos);
            if (pos == 0)
            {
                selectedPet = creatures[i];
                selectAnim = i;
            }
        }
    }
    public void SelectPet()
    {
        var cam = FindObjectOfType<Camera>();
        anim[selectAnim].enabled = false;
        selectedPet.transform.parent = cam.transform;
        selectedPet.transform.localPosition = new Vector3(0, -2, 10);
        UImanager.GetComponent<CameraMove>().MovePos = new Vector3(0, transform.parent.position.y, -10f);
        UImanager.GetComponent<InventoryUIManager>().CloseUI();
        LivingroomUIButtons.SetActive(false);
    }

    public void BackButton()
    {
        selectedPet.transform.parent = this.transform;
        selectedPet.GetComponent<Animator>().enabled = true;
    }
}