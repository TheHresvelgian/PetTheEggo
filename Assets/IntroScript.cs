using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SSS;

public class IntroScript : MonoBehaviour
{
    private List<GameObject> Children;
    private int numb;
    private void Start()
    {
        Children = new List<GameObject>();
        if (File.Exists(SaveStateSystem._dataPath))
        {
            Destroy(gameObject);
            return;
        }
        foreach (Transform child in transform) Children.Add(child.gameObject);
        Next();
    }
    public void Next()
    {
        for (int i = 0; i < Children.Count; i++) Children[i].SetActive(i==numb);
        numb++;
        if(numb == Children.Count +1) Destroy(gameObject);
    }
}