using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffUIonDrag : MonoBehaviour
{
    //public List<Transform> turnOffList;
    public GameObject itemDrag;
    public bool active;

    public void TurnOfList()
    {
        /*foreach (var obj in turnOffList)
        {
            if(obj.name == "CoinCounter") return;
            obj.gameObject.SetActive(false);
        }*/
    }
    private void OnMouseUp1()
    {
        if (!active) return;
        if(itemDrag != null) itemDrag.GetComponent<DragItem>().Drop();
        /*foreach (var obj in turnOffList)
        {
            obj.gameObject.SetActive(true);
        }
        turnOffList.Clear();*/
        active = false;
    }
}
