using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] public List<GameObject> ShopButtons;
    [SerializeField] public List<GameObject> ButtonsTurnOff;
    public List<Animator> textBoxAnim;
    [SerializeField] private GameObject shopCover;

    private void Start()
    {
        foreach (var buttons in ShopButtons)
        {
            if(buttons.GetComponent<Animator>() != null) textBoxAnim.Add(buttons.GetComponent<Animator>());
        }
        ShopButtonsOff();
    }
    
    public void ShopButtonsOn() => StartCoroutine("ShopOn");
    private IEnumerator ShopOn()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var shopButton in ShopButtons) shopButton.SetActive(true);
        foreach (var buttons in ButtonsTurnOff) buttons.SetActive(false);
        foreach (var anim in textBoxAnim) anim.SetBool("Open", true);
    }

    public void ShopButtonsOff()
    {
        foreach (var anim in textBoxAnim) anim.SetBool("Open", false);
        foreach (var shopButton in ShopButtons) shopButton.SetActive(false);
        foreach (var buttons in ButtonsTurnOff) buttons.SetActive(true);
    }
    
    //0 = text knapp av, 1 = text knapp på, 2 = selectmenu knapp av, 3 = selectmenu knapp på
    public void Buttonstate(int OnOff)
    {
        if      (OnOff == 0) textBoxAnim[0].SetBool("Open", false);
        else if (OnOff == 1) textBoxAnim[0].SetBool("Open", true);
        else if (OnOff == 2) textBoxAnim[1].SetBool("Open", false);
        else if (OnOff == 3) textBoxAnim[1].SetBool("Open", true);
    }

    public void ShopCover(bool up) => shopCover.SetActive(up);
}
