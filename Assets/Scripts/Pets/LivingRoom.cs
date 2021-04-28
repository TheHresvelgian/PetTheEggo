using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoom : MonoBehaviour
{
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        transform.position = new Vector3(-23, mainCamera.transform.position.y, 0);
    }
}
