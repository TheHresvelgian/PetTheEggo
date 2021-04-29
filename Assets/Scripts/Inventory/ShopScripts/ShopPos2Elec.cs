using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPos2Elec : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    private Camera _cam;
    private void Start()
    {
        _cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.position = new Vector3(-44.65f + pos.x, _cam.transform.position.y + 5f + pos.y, 0);
    }
}
