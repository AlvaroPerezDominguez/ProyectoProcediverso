using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionPilarBlanco : MonoBehaviour
{
    public float escalaXModificada = 2f; // Escala modificada en el eje X
    public float escalaYModificada = 2f; // Escala modificada en el eje Y
    public float escalaZModificada = 2f; // Escala modificada en el eje Z
    public float tiempoModificacion = 1f; // El tiempo en segundos que tomará la modificación de escala
    public int cantidadCopiasParaEvento = 5; // La cantidad de copias necesarias para detonar el evento

    public FacetasPilar facetasPilar; // Referencia al objeto con el script FacetasPilar


    public FeedbackYEventos feedbackYEventos; // Referencia al objeto con el script FeedbackYEventos

    public List<BrilloPeriferia> objetosBrillo; // Lista de objetos BrilloPeriferia a afectar
    public List<CubeRotation> objetosRotacion; // Lista de objetos CubeRotation a afectar

    private static int contadorCopias = 0; // Variable estática para el contador de copias

    private bool colisionOcurrida = false; // Variable para verificar si la colisión con el clon ya ha ocurrido

    void Start()
    {

        contadorCopias = 0;

        // Buscar todos los objetos en la escena que tengan el componente BrilloPeriferia adjunto
        BrilloPeriferia[] brilloPeriferiaObjects = FindObjectsOfType<BrilloPeriferia>();
        // Agregar los objetos encontrados a la lista objetosBrillo
        objetosBrillo.AddRange(brilloPeriferiaObjects);

        // Buscar todos los objetos en la escena que tengan el componente CubeRotation adjunto
        CubeRotation[] rotationObjects = FindObjectsOfType<CubeRotation>();
        // Agregar los objetos encontrados a la lista objetosRotacion
        objetosRotacion.AddRange(rotationObjects);


    }

    void update() {
        // Buscar todos los objetos en la escena que tengan el componente BrilloPeriferia adjunto
        BrilloPeriferia[] brilloPeriferiaObjects = FindObjectsOfType<BrilloPeriferia>();
        // Limpiar la lista antes de agregar nuevamente los objetos
        objetosBrillo.Clear();
        // Agregar los objetos encontrados a la lista objetosBrillo
        objetosBrillo.AddRange(brilloPeriferiaObjects);


        // Buscar todos los objetos en la escena que tengan el componente CubeRotation adjunto
        CubeRotation[] rotationObjects = FindObjectsOfType<CubeRotation>();
        // Limpiar la lista antes de agregar nuevamente los objetos
        objetosRotacion.Clear();
        // Agregar los objetos encontrados a la lista objetosRotacion
        objetosRotacion.AddRange(rotationObjects);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ReiniciarContadorCopias;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ReiniciarContadorCopias;
    }

    private void ReiniciarContadorCopias(Scene scene, LoadSceneMode mode)
    {
        // Reiniciar el contador de copias a 0 cada vez que se carga una nueva escena
        contadorCopias = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!colisionOcurrida && other.CompareTag("Player"))
        {
            // Modifica la escala del objeto en los ejes X, Y y Z en un tiempo determinado
            StartCoroutine(ModificarEscala());
            DesactivarBoxCollider();

            // Incrementa el contador de copias y verifica si se alcanzó la cantidad deseada
            contadorCopias++;
            Debug.Log("Contador de copias: " + contadorCopias);

            // Llama a la función para aumentar el contador de imágenes en el script FacetasPilar

            Detonador();

            LlamarAumentoImagenes();
            LlamarAumentarIntensidad();
            LlamarAumentarVelocidad();

            if (contadorCopias == cantidadCopiasParaEvento)
            {
                // Llama a la función para detonar el evento deseado
                LlamarPilarNegro();
            }

            // Marcar la colisión como ocurrida para evitar que se incremente el contador nuevamente
            colisionOcurrida = true;
        }
    }

   


    // Función para modificar la escala en los ejes X, Y y Z en un tiempo determinado
    private IEnumerator ModificarEscala()
    {
        Vector3 escalaInicial = transform.localScale;
        Vector3 escalaFinal = new Vector3(escalaXModificada, escalaYModificada, escalaZModificada);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / tiempoModificacion;
            transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, t);
            yield return null;
        }

        // Desactivar el objeto después de que se resuelvan los timers
        gameObject.SetActive(false);
    }


    public void DesactivarBoxCollider()
    {
        // Obtener el componente BoxCollider del objeto actual
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        // Verificar si se encontró el componente
        if (boxCollider != null)
        {
            // Desactivar el BoxCollider
            boxCollider.enabled = false;
        }
        else
        {
            Debug.LogError("No se encontró el componente BoxCollider en este objeto.");
        }
    }

    // Función para llamar el pilar negro cuando se alcance la cantidad de copias deseada
    public void LlamarPilarNegro()
    {

        Debug.Log("Se Llama Pilar Negro");
        // Aquí es donde activamos el script "LlegadaPilarNegro" y llamamos a su función
        LlegadaPilarNegro llegadaPilarNegroScript = GetComponent<LlegadaPilarNegro>();

        if (llegadaPilarNegroScript != null)
        {

            llegadaPilarNegroScript.LlegaPilarNegro();
        }
    }


    public void Detonador()
    {

        Debug.Log("Llamando a detonar eventos");

        if (feedbackYEventos != null) 
      { 
         feedbackYEventos.DetonarEventos();
      }
        else
        {
            Debug.LogWarning("La referencia a feedbackYEventos no está asignada.");
        }


    }

    // Llamar a la función para aumentar el contador de imágenes en el script FacetasPilar
    public void LlamarAumentoImagenes()
    {
        if (facetasPilar != null)
        {
            facetasPilar.IncreaseImageCount();
        }
        else
        {
            Debug.LogWarning("La referencia a FacetasPilar no está asignada.");
        }
    }

    public void LlamarAumentarVelocidad()
    {
      
        if (objetosRotacion != null)
        {
            // Llama a la función AumentarIntensidad en cada objeto BrilloPeriferia de la lista
            foreach (CubeRotation cubeRotation in objetosRotacion)
            {
                cubeRotation.AumentarVelocidad();
            }
        }
        else
        {
            Debug.LogWarning("La referencia a la lista de objetos BrilloPeriferia no está asignada en el Inspector.");
        }
    }

   


    public void LlamarAumentarIntensidad()
    {
        // Asegúrate de que la referencia a la lista de objetos BrilloPeriferia esté asignada en el Inspector
        // if (objetosBrillo != null)
        // {
        //     // Llama a la función AumentarIntensidad en cada objeto BrilloPeriferia de la lista
        //     foreach (BrilloPeriferia brilloPeriferia in objetosBrillo)
        //     {
        //         brilloPeriferia.AumentarIntensidad();
        //     }
        // }
        // else
        // {
        //     Debug.LogWarning("La referencia a la lista de objetos BrilloPeriferia no está asignada en el Inspector.");
        // }

        GameObject cubeMaterialManager = GameObject.Find("CubeMaterialManager");
        cubeMaterialManager.GetComponent<MaterialManager>().AumentarIntensidad();
    }
}