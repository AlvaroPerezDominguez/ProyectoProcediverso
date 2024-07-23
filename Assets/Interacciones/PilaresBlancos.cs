using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaresBlancos : MonoBehaviour
{
    public GameObject PilarPrefab; // Prefab del pilar que se generará como copia
    public int cantidadCopias = 10;
    public float distanciaMinimaEntreCopias = 1.5f;
    public float minDistance = 2f; // Distancia mínima desde el origen (0,0) en X y Z
    public float maxDistance = 5f; // Distancia máxima desde el origen (0,0) en X y Z
    public float fixedY = -6.5f; // Altura fija en el eje Y para las copias

    private List<Vector3> copiasGeneradas = new List<Vector3>(); // Lista para almacenar las posiciones de las copias generadas

    void Start()
    {
        for (int i = 0; i < cantidadCopias; i++)
        {
            // Genera una posición aleatoria para la copia
            Vector3 randomPosition = GetRandomPosition();

            // Verifica si la posición está lo suficientemente separada de las copias anteriores
            if (i > 0)
            {
                while (IsTooCloseToPrevious(randomPosition))
                {
                    randomPosition = GetRandomPosition();
                }
            }

            // Genera un valor aleatorio para determinar si la copia se girará horizontalmente o no
            bool shouldRotate = Random.value < 0.5f;

            // Instancia la copia del pilar y establece su posición y rotación
            GameObject nuevaCopia = Instantiate(PilarPrefab, randomPosition, shouldRotate ? Quaternion.Euler(0f, 90f, 0f) : Quaternion.identity);

            // Almacena la posición de la copia generada
            copiasGeneradas.Add(randomPosition);
        }
    }

    // Genera una posición aleatoria dentro del rango establecido
    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(minDistance, maxDistance) * (Random.value < 0.5f ? 1 : -1);
        float randomZ = Random.Range(minDistance, maxDistance) * (Random.value < 0.5f ? 1 : -1);
        float randomY = fixedY; // Establece la altura fija para todas las copias

        return new Vector3(randomX, randomY, randomZ);
    }

    // Verifica si la posición está demasiado cerca de las copias anteriores
    bool IsTooCloseToPrevious(Vector3 position)
    {
        foreach (Vector3 generatedPosition in copiasGeneradas)
        {
            if (Vector3.Distance(position, generatedPosition) < distanciaMinimaEntreCopias)
            {
                return true;
            }
        }
        return false;
    }
}