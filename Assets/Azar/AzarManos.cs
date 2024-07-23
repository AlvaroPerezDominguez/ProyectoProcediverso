using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarManos : MonoBehaviour
{
    public Material material;


    private void Awake()
    {

        ModifyMaterials();

    }

    private void Start()
    {
        ModifyMaterials();
    }

    private void ModifyMaterials()
    {
        
            if (material != null)
            {
                // Modificar los valores generales del material al azar
                Color randomColor = Random.ColorHSV(0f, 1f, 0f, 0.05f, 1f, 1f);
                material.color = randomColor;
                material.SetFloat("_Metallic", Random.Range(0f, 1f));
                material.SetFloat("_Glossiness", Random.Range(0f, 1f));
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
