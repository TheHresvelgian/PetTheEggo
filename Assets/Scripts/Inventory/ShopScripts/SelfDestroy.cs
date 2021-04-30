using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SelfDestroy : MonoBehaviour
{
    private GameObject markusAnim;
    private Animator anim;
    [SerializeField] private List<AudioClip> playOnStart;
    [SerializeField] private List<AudioClip> playOnYes;
    [SerializeField] private List<AudioClip> playOnNo;
    private AudioSource Source;
    

    public void Start()
    {
        markusAnim = GameObject.FindGameObjectWithTag("MarkusTheMighty");
        anim = markusAnim.GetComponent<Animator>();
        markusAnim.GetComponent<ShopPos>().select = true;
        anim.SetBool("Select", true);
        Source = FindObjectOfType<Camera>().GetComponent<AudioSource>();
        Source.PlayOneShot(playOnStart[Random.Range(0, playOnStart.Count - 1)]);
    }
    public void Yes()
    {
        Source.PlayOneShot(playOnYes[Random.Range(0, playOnYes.Count - 1)]);
        Destroy();
    }
    public void No()
    {
        Source.PlayOneShot(playOnNo[Random.Range(0, playOnNo.Count - 1)]);
        Destroy();
    }
    public void Destroy()
    {
        markusAnim.GetComponent<ShopPos>().select = false;
        anim.SetBool("Select", false);
        Destroy(gameObject);
    }
}
