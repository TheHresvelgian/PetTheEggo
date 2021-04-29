using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class DragItem : MonoBehaviour
{
    public ItemObjects ItemObjects;
    [SerializeField] private InventoryObject playerInv;
    private Camera cam;
    private Vector3 pos;
    private bool back;
    public GameObject pressControll;
    private Vector3 smoothdamp;
    private Vector3 movePos;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.3f;
    private void Start()
    {
        movePos = transform.position;
        cam = FindObjectOfType<Camera>();
        GetComponent<SpriteRenderer>().sprite = ItemObjects.sprite;
        
        pressControll.GetComponent<TurnOffUIonDrag>().itemDrag = gameObject;
    }

    private void Update()
    {
        pos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (back)
        {
            smoothdamp = Vector3.SmoothDamp(transform.position, movePos, ref velocity, smoothTime);
            transform.position = smoothdamp;
        }
        else transform.position = new Vector3(pos.x, pos.y, 0f);
    }

    public void Drop()
    {
        back = true;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("destroy");
    }

    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(smoothTime);
        playerInv.AddItem(ItemObjects, 1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.CompareTag("Creature"))
        {
            
        }
    }
}
