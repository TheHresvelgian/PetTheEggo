using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPos : MonoBehaviour
{
    private Camera _cam;
    private void Start()
    {
        _cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.position = new Vector3(-44.65f, _cam.transform.position.y + 5f, 0);
    }
}
