using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilarNegro : MonoBehaviour
{
    public CinematicaFinal cinematicaFinal; // Referencia al objeto con el script CinematicaFinal

    [Header("Posicion de spawn")]
    public float minDistance = 2f; // Distancia mínima desde el origen (0,0) en X y Z
    public float maxDistance = 5f; // Distancia máxima desde el origen (0,0) en X y Z


    private bool colisionOcurrida = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&(!colisionOcurrida))
        {
            LlamarCinematicaFinal();
            colisionOcurrida = true;
        }
    }

    public void LlamarCinematicaFinal()
    {
        Debug.Log("llamando cinematica final");

        if (cinematicaFinal != null)
        {
            cinematicaFinal.DetonarCinematica();
        }
        else
        {
            Debug.LogWarning("La referencia a cinematicaFinal no está asignada.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Genera valores aleatorios para la distancia desde el origen (0,0)
        float randomDistanceX = Random.Range(minDistance, maxDistance);
        float randomDistanceZ = Random.Range(minDistance, maxDistance);

        // Establece la nueva posición dentro del margen establecido
        float randomX = Random.Range(0f, 1f) < 0.5f ? randomDistanceX : -randomDistanceX;
        float randomZ = Random.Range(0f, 1f) < 0.5f ? randomDistanceZ : -randomDistanceZ;

        // Asigna las nuevas coordenadas al cubo activo
        Vector3 newPosition = new Vector3(randomX, transform.position.y, randomZ);
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
}