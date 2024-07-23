using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarSkybox : MonoBehaviour
{
    public Material skybox;

    private void Start()
    {
        ModifySkybox();
    }

    private void ModifySkybox()
    {
        if (skybox != null)
        {
            // Modificar los valores generales del skybox al azar
            skybox.SetFloat("_SunSize", Random.Range(0.076f, 0.30f));
            skybox.SetFloat("_SunSizeConvergence", Random.Range(1f, 5f));
            skybox.SetFloat("_AtmosphereThickness", Random.Range(0.85f, 2.33f));

            skybox.SetColor("_SkyTint", Random.ColorHSV(0f, 1, 0.25f, 1, 0.25f, 1f));
            skybox.SetColor("_GroundColor", Random.ColorHSV(0f, 1, 0.25f, 1, 0.25f, 1f));

            skybox.SetFloat("_Exposure", Random.Range(0.45f, 1.75f));
            // ... Agrega aquí más modificaciones según tus necesidades
        }
    }
}