using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaPilarNegro : MonoBehaviour
{
    [System.Serializable]
    public class MeshData
    {
        public GameObject meshObject;
        public float escalaXFinal = 4f; // Escala final en el eje X
        public float escalaZFinal = 4f; // Escala final en el eje Z
    }

    public MeshData meshData1;
    public MeshData meshData2;
    public float tiempoModificacion = 5f; // El tiempo en segundos que tomará la modificación de escala

    private bool isAnimating = false;
    private float animationTime = 0f; // Tiempo actual de la animación

    private Vector3 escalaInicial;
    private Vector3 escalaFinal;

    public void LlegaPilarNegro()
    {
        Debug.Log("llega pilar negro");

        if (!isAnimating)
        {
            // Activa el objeto mesh antes de comenzar la animación
            meshData1.meshObject.SetActive(true);
            meshData2.meshObject.SetActive(true);

            // Guarda la escala inicial antes de la animación
            escalaInicial = meshData1.meshObject.transform.localScale;
            escalaInicial = meshData2.meshObject.transform.localScale;

            // Calcula la escala final deseada
            escalaFinal = new Vector3(meshData1.escalaXFinal, meshData1.meshObject.transform.localScale.y, meshData1.escalaZFinal);
            escalaFinal = new Vector3(meshData2.escalaXFinal, meshData2.meshObject.transform.localScale.y, meshData2.escalaZFinal);

            // Inicia la animación
            StartCoroutine(ModificarEscala());
        }
    }

    private void Update()
    {
        if (isAnimating)
        {
            animationTime += Time.deltaTime;

            if (animationTime < tiempoModificacion)
            {
                float t = animationTime / tiempoModificacion;

                // Calcula la escala interpolada
                Vector3 escalaInterpolada = Vector3.Lerp(escalaInicial, escalaFinal, t);

                // Aplica la escala interpolada al objeto mesh
                meshData1.meshObject.transform.localScale = new Vector3(escalaInterpolada.x, meshData1.meshObject.transform.localScale.y, escalaInterpolada.z);
                meshData2.meshObject.transform.localScale = new Vector3(escalaInterpolada.x, meshData2.meshObject.transform.localScale.y, escalaInterpolada.z);
            }
            else
            {
                // Termina la animación y reinicia
                isAnimating = false;
                animationTime = 0f;
            }
        }
    }

    

    private IEnumerator ModificarEscala()
    {
        float elapsedTime = 0f;

        while (elapsedTime < tiempoModificacion)
        {
            float t = elapsedTime / tiempoModificacion;

            // Calcula la escala interpolada
            Vector3 escalaInterpolada = Vector3.Lerp(escalaInicial, escalaFinal, t);

            // Aplica la escala interpolada al objeto mesh
            meshData1.meshObject.transform.localScale = new Vector3(escalaInterpolada.x, meshData1.meshObject.transform.localScale.y, escalaInterpolada.z);
            meshData2.meshObject.transform.localScale = new Vector3(escalaInterpolada.x, meshData2.meshObject.transform.localScale.y, escalaInterpolada.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Finaliza la animación y restablece los valores
        meshData1.meshObject.transform.localScale = escalaFinal;
        meshData2.meshObject.transform.localScale = escalaFinal;

        isAnimating = false;
    }
}