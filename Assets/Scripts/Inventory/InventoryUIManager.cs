using System.Collections.Generic;
using UnityEngine;

    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        [SerializeField] private List<GameObject> uiGameObjects;

        public string curentMenu;
        public bool open;
        private Vector3 moveTowards = new Vector3(250f, 0, 0);
        private Vector3 moveSpeed = Vector3.one;
        private Vector3 SmoothDamp;

        public void Opening(string selectedMenu)
        {
            open = !open;
            if (!open) moveTowards = new Vector3(270f, 0, 0);
            if (open)  moveTowards = new Vector3(0f, 0, 0);
            curentMenu = selectedMenu;
            if (!open) return;
            foreach (var BackGrounds in uiGameObjects)
            {
                BackGrounds.SetActive(BackGrounds.name == curentMenu);
            }
        }

        private void Update()
        {
            if (transform.localPosition != moveTowards) Movement();
        }

        private void Movement()
        {
            SmoothDamp = Vector3.SmoothDamp(transform.localPosition, new Vector3(moveTowards.x + 20f, moveTowards.y, moveTowards.z), ref moveSpeed, moveTime);
            transform.localPosition = SmoothDamp;
        }
    }
