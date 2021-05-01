using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.Sheepy;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private AnimationCurve jumpCurve;
    private float timer;
    private bool Jumping;
    private float baseY = 9.2f;
    private float timerSpeed;
    [SerializeField] private SheepMovement sheepMovement;
    
    public void Jump() => Jumping = true;

    private void OnEnable()
    {
        timerSpeed = 0;
        transform.parent.GetComponent<Animator>().speed = 0.2f; //* timerSpeed;
    }

    private void Update()
    {
        timerSpeed = 1f + Time.deltaTime * 0.001f;
        if (!Jumping) return;
        timer += Time.deltaTime;
        transform.localPosition = new Vector3(0,jumpCurve.Evaluate(timer * 2) + baseY, 0);
        if (timer >= 0.5f) Jumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent = null;
        GetComponent<Animator>().SetTrigger("GameOver");
        sheepMovement.GameOver();

    }
}
