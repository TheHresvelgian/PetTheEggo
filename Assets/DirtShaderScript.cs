using System;
using System.Collections;
using System.Collections.Generic;
using DataContainers;
using Pets;
using UnityEngine;

public class DirtShaderScript : MonoBehaviour
{
    private Material dirtShader;
    [SerializeField] private PetScrubBase petScrub;
    private float Alpha;

    private void Start()
    {
        dirtShader = GetComponent<SpriteRenderer>().material;
        ShaderUpdate();
    }

    private void Update() => ShaderUpdate();

    public void ShaderUpdate()
    {
        Alpha = 1 - petScrub.clean / 100f;
        dirtShader.SetFloat("Vector1_a1d20084c502438f8501941b48084615", Alpha);
    }
}
