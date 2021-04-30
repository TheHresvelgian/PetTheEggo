using System;
using System.Collections;
using System.Collections.Generic;
using Pets;
using UnityEngine;
using UnityEngine.UI;

public class SheepyCheck : MonoBehaviour
{
    [SerializeField] private GameObject creature;
    [SerializeField] private PetScript script;
    private int sleepiness;
    private Image img;

    public void OnEnable()
    {
        script = creature.GetComponent<CreatureController>().selectedPet.GetComponent<PetScript>();
        img = GetComponent<Image>();
        StartCoroutine(nameof(UpdateSleepiness));
    }

    public void OnDisable()
    {
        StopCoroutine(nameof(UpdateSleepiness));
    }

    private IEnumerator UpdateSleepiness()
    {
        sleepiness = script.information.sleepy;
        GetComponent<Button>().enabled = sleepiness <= 31;
        if(sleepiness >= 31) img.color = Color.gray;
        else img.color = Color.white;
        yield return new WaitForSeconds(45f);
        StartCoroutine(nameof(UpdateSleepiness));
    }
}
