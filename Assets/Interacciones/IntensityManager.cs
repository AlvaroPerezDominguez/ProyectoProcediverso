using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityManager : MonoBehaviour
{
        // Propiedad compartida de intensidad
    public static float SharedEmissionIntensity { get; private set; }

    // Método para actualizar la intensidad compartida
    public static void UpdateSharedIntensity(float newIntensity)
    {
        SharedEmissionIntensity = newIntensity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
