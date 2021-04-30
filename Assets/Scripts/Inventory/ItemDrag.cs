using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler
{
    public ItemObjects ItemObjects;
    private Image img;
    private Camera cam;
    private GameObject InstatObj;
    private Canvas canvas;
    private GameObject pressControler;
    [SerializeField] public List<Transform> turnOffList;
    [SerializeField] private GameObject PressControll;
    [SerializeField] private InventoryObject playerInv;
    [SerializeField] private Vector3 InstatiatePos = new Vector3(8,0,0);
    [SerializeField] private GameObject itemPrefab;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        img = GetComponent<Image>();
        canvas = FindObjectOfType<Canvas>();
        pressControler = transform.parent.parent.gameObject.GetComponent<InventoryController>().pressControl;
    }

    public void Startup()
    {
        if (ItemObjects != null && img != null) img.sprite = ItemObjects.sprite;
        else transform.parent.gameObject.SetActive(false);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (Transform obj in canvas.transform)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                turnOffList.Add(obj);
            }
        }
        InstatObj = Instantiate(itemPrefab, InstatiatePos, Quaternion.Euler(0,0,0), cam.transform);
        InstatObj.GetComponent<DragItem>().ItemObjects = ItemObjects;
        InstatObj.GetComponent<DragItem>().pressControll = pressControler;
        playerInv.AddItem(ItemObjects, -1);
        
        //pressControler.GetComponent<TurnOffUIonDrag>().turnOffList = turnOffList;
        pressControler.GetComponent<TurnOffUIonDrag>().TurnOfList();
        pressControler.GetComponent<TurnOffUIonDrag>().active = true;
        //turnOffList.Clear();
    }
}
