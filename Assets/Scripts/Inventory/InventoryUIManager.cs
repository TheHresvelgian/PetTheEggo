using System;
using System.Collections.Generic;
using UnityEngine;

    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        [SerializeField] private List<GameObject> uiGameObjects;
        [SerializeField] private List<GameObject> uiButtons;
        [SerializeField] public List<GameObject> uiTurnOffDragItem;

        public string curentMenu = "Guardan";
        [SerializeField] private GameObject LivingRoomButtons;
        [SerializeField] private GameObject CreatureController;
        public bool draged;
        public bool open;
        private Vector3 moveTowards = new Vector3(-20f, 0, 0);
        private Vector3 moveSpeed = Vector3.one;
        private Vector3 SmoothDamp;
        private CameraMove CameraMove;
        private float moveCamera;
        private string curentButton = "GuardanButton";

        private void Start()
        {
            CameraMove = GetComponent<CameraMove>();
            moveTowards = new Vector3(60,0,0);
        }
        public void Opening(string selectedMenu)
        {
            curentMenu = selectedMenu;
            foreach (var BackGrounds in uiGameObjects)
            {
                BackGrounds.SetActive(BackGrounds.name == curentMenu);
            }
            if (curentMenu == "Guardan") moveCamera = 0f;
            else if (curentMenu == "Bathroom") moveCamera = 10f;
            else if (curentMenu == "Kitchen") moveCamera = 20f;
            CameraMove.MoveCamera(moveCamera);
        } 
        public void TurningButtonsOff(string buttonName)
        {
            curentButton = buttonName;
             foreach (var button in uiButtons)
             {
                 button.SetActive(button.name != buttonName);
             }
        }

        public void CloseUI()
        {
            open = false;
            moveTowards = new Vector3(-20, 0, 0);
            TurningButtonsOff(curentButton);
        }
        public void OpenUI()
        {
            open = true;
            moveTowards = new Vector3(-266, 0, 0);
            
        }
        public void BackButtonInv()
        {
            moveTowards = new Vector3(50, 0, 0);
            open = false;
            foreach (var button in uiButtons)
            {
                button.SetActive(false);
            }
            LivingRoomButtons.SetActive(true);
            CreatureController.GetComponent<CreatureController>().BackButton();
        }
        private void Update()
        {

            if (draged && transform.localPosition.x <= -70f)
            {
                open = true;
                moveTowards = new Vector3(-266, 0, 0);
            }

            else if (draged && transform.localPosition.x >= -216)
            {
                open = false;
                moveTowards = new Vector3(-20, 0, 0);
            }

            if (transform.localPosition.x <= -266) transform.localPosition = new Vector3(-266, 0, 0);
            if (!draged) Movement();
        }

        private void Movement()
        {
            SmoothDamp = Vector3.SmoothDamp(transform.localPosition, new Vector3(moveTowards.x + 10f, moveTowards.y, moveTowards.z), ref moveSpeed, moveTime);
            transform.localPosition = SmoothDamp;
        }
    }
