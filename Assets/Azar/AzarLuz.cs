using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AzarLuz : MonoBehaviour
{
    private void Start()
    {
        // Obtener todas las luces en la escena
        Light[] lights = FindObjectsOfType<Light>();

        // Modificar los parámetros de todas las luces
        foreach (Light light in lights)
        {
            // Cambiar el color de la luz al azar
            light.color = Random.ColorHSV(0f, 1, 0.25f, 0.75f, 0.25f, 1); ;

            // Cambiar la intensidad de la luz al azar
            light.intensity = Random.Range(0.75f, 5f);

            if (SceneManager.GetActiveScene().name == "Game")
            {
                // Cambiar la dirección de la luz al azar
                light.transform.rotation = Quaternion.Euler(Random.Range(5f, 75f), Random.Range(-180f, 180f), 0f);
            }
            else
            {
                light.transform.rotation = Quaternion.Euler(Random.Range(5f, 75f), Random.Range(90f, 270f), 0f);
            }                                    
        }
    }
}