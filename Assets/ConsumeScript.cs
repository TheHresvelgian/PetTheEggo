using System;
using System.Collections;
using System.Collections.Generic;
using Pets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConsumeScript : MonoBehaviour
{
    private float SoapDurability;
    [SerializeField] private float DurabilityScale = 50;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            other.GetComponent<DragItem>().tuch = true;
            gameObject.GetComponent<PetScript>().information.hunger += other.GetComponent<DragItem>().ItemValue;
            StartCoroutine(nameof(SpriteEmote));
            Destroy(other.GetComponent<Collider2D>().gameObject);
            UpdateInv();
        }

        if (other.CompareTag("Soap") && !other.GetComponent<DragItem>().tuch)
        {
            other.GetComponent<DragItem>().tuch = true;
            SoapDurability = 100;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Soap") && Vector2.SqrMagnitude(Mouse.current.delta.ReadValue()) != 0)
        {
            SoapDurability -= Time.deltaTime * DurabilityScale;
            if (SoapDurability <= 0)
            {
                gameObject.GetComponent<PetScript>().information.clean += other.GetComponent<DragItem>().ItemValue;
                StartCoroutine(nameof(SpriteEmote));
                Destroy(other.gameObject);
                UpdateInv();
            }
        }
    }

    private void UpdateInv() => GameObject.FindGameObjectWithTag("InvPannel").GetComponent<InventoryController>().GenerateList();

    private IEnumerator SpriteEmote()
    {
        var spriteBefore = GetComponent<PetScript>().spriteList;
        GetComponent<PetScript>().spriteList = GetComponent<PetScript>().happy;
        GetComponent<PetScript>().Start();
        yield return new WaitForSeconds(2f);
        GetComponent<PetScript>().spriteList = spriteBefore;
        GetComponent<PetScript>().Start();
    }
    
}
