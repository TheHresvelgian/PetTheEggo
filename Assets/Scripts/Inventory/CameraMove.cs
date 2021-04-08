using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 mousePos;
    [SerializeField] private float dragDistance;
    private bool drag;
    [SerializeField] private Vector2 deltaMouse;
    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (drag) mainCamera.transform.position += new Vector3(0f, deltaMouse.y, 0f);
        print(deltaMouse);
    }

    private void OnMouseDown1() => mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    private void OnLook(InputValue value)
    {
        deltaMouse = value.Get<Vector2>();
        print(deltaMouse);
    }

    private void OnMouseUp1()
    {
        print(Vector2.Distance(mousePos, mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue())));
        drag = false;
    }
    public void Select(bool up)
    {
        drag = true;
    }
}
