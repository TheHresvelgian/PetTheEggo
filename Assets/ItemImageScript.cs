using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImageScript : MonoBehaviour
{
    public void Startup(Sprite img, Vector3 pos)
    {
        GetComponent<Image>().sprite = img;
        GetComponent<RectTransform>().position = pos;
    }
}
