using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class DragQueen : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Touch _touch;
    private RectTransform _rectTransform;
    private InventoryUIManager _UiManager;
    [SerializeField] private GameObject dragManager;

    private void Awake()
    {
        _rectTransform = dragManager.GetComponent<RectTransform>();
        _UiManager = dragManager.GetComponent<InventoryUIManager>();
    }
    public void OnDrag(PointerEventData eventData)
    {
     
        _rectTransform.anchoredPosition += new Vector2(eventData.delta.x, 0f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _UiManager.draged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _UiManager.draged = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
           
        }
    }
}
