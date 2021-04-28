using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float MoveTime = 2f;
    private Camera MainCamera;
    private Vector3 SmoothDamp;
    public Vector3 MovePos;
    private Vector3 Velocity = Vector3.zero;

    private void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        MovePos = new Vector3(-23,0,-10f);
    }

    public void BackButton() => MovePos = new Vector3(-23, MovePos.y, MovePos.z);
    public void MarkusButton() => MovePos = new Vector3(-46, MovePos.y, MovePos.z);
    public void MoveCamera(float pos)
    {
        MovePos = new Vector3(0,pos,-10f);
    }
    private void Update()
    {
        SmoothDamp = Vector3.SmoothDamp(MainCamera.transform.position, MovePos, ref Velocity, MoveTime);
        MainCamera.transform.position = SmoothDamp;
    }
}
