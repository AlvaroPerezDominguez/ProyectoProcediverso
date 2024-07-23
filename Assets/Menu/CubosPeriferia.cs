using System.Collections.Generic;
using UnityEngine;

public class CubosPeriferia : MonoBehaviour
{
    public GameObject CuboPrefab; // Prefab del cubo que se generará como copia
    public GameObject PilaresBlancos; 

    public int cantidadCopias = 10;
    public float distanciaMinima = 2f;
    public float distanciaMaxima = 5f;
    public float margenYMinimo = 0f;
    public float margenYMaximo = 2f;
    public float distanciaMinimaEntreCopias = 1.5f;
    public float distanciaMaximaParaActivarRotacion = 20f;

    private List<Vector3> copiasGeneradas = new List<Vector3>(); // Lista para almacenar las posiciones de las copias generadas


    void Start()
    {
        GameObject player = GameObject.Find("Player");
        for (int i = 0; i < cantidadCopias; i++)
        {
            // Genera valores aleatorios para la distancia desde el origen (0,0)
            float randomDistanceX = Random.Range(distanciaMinima, distanciaMaxima);
            float randomDistanceZ = Random.Range(distanciaMinima, distanciaMaxima);

            // Establece la nueva posición dentro del margen establecido
            float randomX = Random.Range(0f, 1f) < 0.5f ? randomDistanceX : -randomDistanceX;
            float randomZ = Random.Range(0f, 1f) < 0.5f ? randomDistanceZ : -randomDistanceZ;

            // Genera un valor aleatorio para el eje Y dentro del margen establecido
            float randomY = Random.Range(margenYMinimo, margenYMaximo);

            // Calcula la nueva posición para la copia
            Vector3 newPosition = new Vector3(randomX, randomY, randomZ);

            // Verifica si la posición está lo suficientemente separada de las copias anteriores
            if (i > 0)
            {
                while (Vector3.Distance(newPosition, transform.position + copiasGeneradas[i - 1]) < distanciaMinimaEntreCopias)
                {
                    randomX = Random.Range(0f, 1f) < 0.5f ? Random.Range(distanciaMinima, distanciaMaxima) : -Random.Range(distanciaMinima, distanciaMaxima);
                    randomZ = Random.Range(0f, 1f) < 0.5f ? Random.Range(distanciaMinima, distanciaMaxima) : -Random.Range(distanciaMinima, distanciaMaxima);
                    newPosition = new Vector3(randomX, randomY, randomZ);
                }
            }

            // Instancia la copia del cubo y establece su posición
            GameObject nuevaCopia = Instantiate(CuboPrefab, transform.position + newPosition, Quaternion.identity);

            // Almacena la posición de la copia generada
            copiasGeneradas.Add(newPosition);

            float distanceToCamera = Vector3.Distance(newPosition, player.transform.position);

            // NUEVO
            if (distanceToCamera > distanciaMaximaParaActivarRotacion) 
            {
                nuevaCopia.GetComponent<CubeRotation>().enabled = false;
            }

            // Asigna el material aleatorio al cubo copia
            MeshRenderer meshRendererCopia = nuevaCopia.GetComponent<MeshRenderer>();
            if (meshRendererCopia != null)
            {
                // NUEVO
                GameObject CubeMaterialManager = GameObject.Find("CubeMaterialManager");
                meshRendererCopia.material = CubeMaterialManager.GetComponent<MaterialManager>().getRandomMaterial();
            }
        }

        // Luego, activa los Pilares Blancos
        ActivarPilaresBlancos();
    }

    void ActivarPilaresBlancos()
    {
        // Asegúrate de que la variable PilaresBlancos no sea nula
        if (PilaresBlancos != null)
        {
            PilaresBlancos.SetActive(true);
        }
        else
        {
            Debug.LogError("La variable 'PilaresBlancos' no ha sido asignada en el Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}