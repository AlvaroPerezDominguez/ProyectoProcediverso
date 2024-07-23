using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopiarPosicion : MonoBehaviour
{
    public Transform objetoFuente; // El objeto cuya posición se va a copiar

    void Start()
    {
        if (objetoFuente != null)
        {
            // Obtener la posición actual del objeto fuente
            Vector3 posicionFuente = objetoFuente.position;

            // Copiar los valores de "eje X" y "eje Z" al objeto actual
            Vector3 nuevaPosicion = new Vector3(posicionFuente.x, transform.position.y, posicionFuente.z);

            // Establecer la nueva posición en el objeto actual
            transform.position = nuevaPosicion;
        }
        else
        {
            Debug.LogError("Objeto fuente no asignado. Asigna un objeto en el inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
