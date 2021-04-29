using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPos : MonoBehaviour
{
    private Camera _cam;
    private Animator _animator;
    [SerializeField] private Vector3 selectDistance;
    public bool select;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        if (select)
        {
            transform.position = new Vector3(-44.65f + selectDistance.x, _cam.transform.position.y + 5f + selectDistance.y, 0);
        }
        else
        {
            transform.position = new Vector3(-44.65f, _cam.transform.position.y + 5f, 0);
        }
        
    }
}
