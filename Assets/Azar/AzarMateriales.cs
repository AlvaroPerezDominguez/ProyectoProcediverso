using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarMateriales : MonoBehaviour
{
    public Material[] materials;

    private void Start()
    {
        ModifyMaterials();
    }

    private void ModifyMaterials()
    {
        foreach (Material material in materials)
        {
            if (material != null)
            {
                // Modificar los valores generales del material al azar
                Color randomColor = Random.ColorHSV(0f, 1, 0.3f, 1, 0.3f, 1); 
                material.color = randomColor;
                material.SetFloat("_Metallic", Random.Range(0f, 1f));
                material.SetFloat("_Glossiness", Random.Range(0f, 1f));
            }
        }
    }
}