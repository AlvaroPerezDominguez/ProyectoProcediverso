using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrilloPeriferia : MonoBehaviour
{
    public Renderer objectRenderer; // El Renderer del objeto con el material de emisión HDR
    public Color emissionColor = Color.white; // Color de emisión HDR
    public float emissionIntensity = 0; // Variable de intensidad de emisión

    [Header("Rango de Intensidad de Emisión")]
    public float minEmissionIntensity = 0.0f; // Valor mínimo de intensidad de emisión
    public float maxEmissionIntensity = 2.0f; // Valor máximo de intensidad de emisión

    private Material material; // El material del objeto

    private void Start()
    {
        // Asegúrate de que el objeto tiene un Renderer
        if (objectRenderer == null)
        {
            Debug.LogError("No se ha asignado un Renderer en el Inspector.");
            enabled = false; // Desactiva el script si no se asigna un Renderer
            return;
        }

        material = objectRenderer.material;

        // Establece emissionIntensity inicial dentro del rango definido
        emissionIntensity = Random.Range(minEmissionIntensity, maxEmissionIntensity);

        emissionColor = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }

    public void AumentarIntensidad()
    {
      //  Debug.Log("Aumentando intensidad...");
        emissionIntensity = emissionIntensity * Random.Range(3, 1.75f);

    }

    private void Update()
    {
        // Actualiza el color de emisión HDR y la intensidad en el material
        material.SetColor("_EmissionColor", emissionColor * emissionIntensity);

        // Activa la emisión si la intensidad es mayor que cero
        if (emissionIntensity > 0)
        {
            material.EnableKeyword("_EMISSION");
        }
        else
        {
            material.DisableKeyword("_EMISSION");
        }
    }
}