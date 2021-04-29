using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private GameObject markusAnim;
    private Animator anim;
    

    public void Start()
    {
        markusAnim = GameObject.FindGameObjectWithTag("MarkusTheMighty");
        anim = markusAnim.GetComponent<Animator>();
        markusAnim.GetComponent<ShopPos>().select = true;
        anim.SetBool("Select", true);
    }

    public void Destroy()
    {
        markusAnim.GetComponent<ShopPos>().select = false;
        anim.SetBool("Select", false);
        Destroy(gameObject);
    }
}
