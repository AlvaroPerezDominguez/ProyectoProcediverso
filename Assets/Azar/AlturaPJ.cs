using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlturaPJ : MonoBehaviour
{
    public float minHeight = 0.55f; // Altura mínima permitida para el CharacterController
    public float maxHeight = 1.0f; // Altura máxima permitida para el CharacterController

    // Use este evento en lugar de Start para retrasar el cambio de altura
    private IEnumerator Start()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            // Esperar un frame para asegurar que el CharacterController se inicializa completamente
            yield return null;

            // Generar un valor aleatorio entre minHeight y maxHeight para la altura del CharacterController
            float randomHeight = Random.Range(minHeight, maxHeight);
            characterController.height = randomHeight;

            // Obtener la cámara principal (Main Camera)
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                // Asignar la mitad del valor aleatorio de altura al eje Y de la posición de la cámara
                Vector3 cameraPosition = mainCamera.transform.position;
                cameraPosition.y = randomHeight * 0.5f;
                mainCamera.transform.position = cameraPosition;
            }
            else
            {
                Debug.LogWarning("Main Camera not found!");
            }
        }
        else
        {
            Debug.LogWarning("CharacterController not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
