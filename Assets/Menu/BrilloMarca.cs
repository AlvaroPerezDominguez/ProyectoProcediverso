using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrilloMarca : MonoBehaviour
{
    public Renderer objectRenderer; // El Renderer del objeto con el material
    private Material material; // El material del objeto

    public float luminosidad = 1.0f;  // Valor inicial de la luminosidad (1.0 es el valor por defecto)

    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {

        if (objectRenderer != null)
        {
            // Obtén el material del objeto
            material = objectRenderer.material;

            // Modifica la luminosidad del material
            Color color = material.color;
            color = ColorHSV(color.r, color.g, luminosidad);
            material.color = color;
        }

        // Función para modificar la luminosidad del color
        Color ColorHSV(float h, float s, float v)
        {
            Color.RGBToHSV(new Color(h, s, v), out h, out s, out v);
            return Color.HSVToRGB(h, s, v);
        }
    }
}