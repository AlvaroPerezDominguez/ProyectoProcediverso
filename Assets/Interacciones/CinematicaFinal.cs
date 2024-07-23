using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class CinematicaFinal : MonoBehaviour
{
    private Vector3 posicionInicialJugador; // La posición inicial del jugador
    private Vector3 posicionFinalJugador; // La posición final del jugador (posición del objeto mesh)
    private bool movimientoIniciado = false; // Controla si el movimiento se ha iniciado
    private GameObject audioSourceObjeto; // Variable para almacenar el objeto con el AudioSource

    [Header("Objetos")]
    public Transform objetoMesh; // El objeto mesh al que el jugador se moverá
    public Material skyboxMaterial; // Material del skybox
    public AudioSource audioSource; // Aquí asigna el AudioSource que quieres modificar
    public Light directionalLight; // Asigna la Directional Light en el Inspector
    public PostProcessProfile postProcessProfile; // Asigna el perfil de Post-Processing en el Inspector
    public Material manosMaterial;

    private ColorGrading colorGrading; // Referencia a las configuraciones de ColorGrading
    private AmbientOcclusion ambientOcclusion;

    [Header("LuzSol")]
    private float initialIntensity; // Intensidad inicial de la Directional Light
    private float targetIntensity = 0f; // Intensidad objetivo

    [Header("Variables de tiempo")]
    public float duracionMovimiento = 2.0f; // Duración en segundos del movimiento
    public float resta = 1.0f;
    private float tiempoPasado = 0.0f; // Tiempo transcurrido

    [Header("Ambient Oclusion")]
    private float initialAOIntensity;
    public float targetAOIntensity = 1f; // Cambia esto al valor deseado

    private float initialthicknessModifier;
    public float targetthicknessModifier = 1f; // Cambia esto al valor deseado

    private Color initialcolor;
    public Color targetcolor;

    private Color manosInicial;

    [Header("Color Grading")]
    private float initialSaturation;
    public float targetSaturation = 1f; // Cambia esto al valor deseado

    private float initialContrast;
    public float targetContrast = 1f; // Cambia esto al valor deseado

    [Header("skybox")]
    private float initialSunSize;
    private float targetSunSize = 0f;

    private float initialExposure; // Exposición inicial del skybox
    private float targetExposure = 0f; // Exposición objetivo

    [Header("Audio")]
    public float pitchInicial = 1.0f; // Pitch inicial del AudioSource
    public float pitchFinal = 2.0f; // Pitch al que quieres cambiar

    [Header("Cambiar a la escena:")]
    public string Menu; // Nombre de la escena a la que quieres cambiar

    public void DetonarCinematica()
    {
        Debug.Log("detonando cinematica");

        // Iniciar el movimiento desde la posición actual del jugador
        posicionInicialJugador = transform.position;

        // Calcular la posición final del jugador (posición del objeto mesh)
        posicionFinalJugador = objetoMesh.position;
        posicionFinalJugador.y -= resta;
        posicionFinalJugador.x -= resta;
        movimientoIniciado = true;

        // Configurar el pitch del AudioSource
        audioSource.pitch = pitchInicial;

        // Buscar el objeto que contiene el AudioSource
        audioSourceObjeto = GameObject.Find("PilarNegro");
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Obtener la intensidad inicial de la Directional Light
        if (directionalLight != null)
        {
            initialIntensity = directionalLight.intensity;
        }
        else
        {
            Debug.LogError("No se encontró una Directional Light. Asegúrate de asignar una en el Inspector.");
        }

       skyboxMaterial = RenderSettings.skybox;
        if (skyboxMaterial != null)
        {
            // Guarda la exposición inicial del skybox
            initialExposure = RenderSettings.skybox.GetFloat("_Exposure");
            initialSunSize = RenderSettings.skybox.GetFloat("_SunSize");

}
        else
        {
            Debug.LogError("No se encontró un material de skybox. Asegúrate de asignar uno en el Inspector.");
        }


        
        if (manosMaterial != null)
        {
            // Guarda la exposición inicial de las manos
         manosInicial = manosMaterial.color;

        }
        else
        {
            Debug.LogError("No se encontró un material de las manos. Asegúrate de asignar uno en el Inspector.");
        }


        // Obtener las configuraciones de ColorGrading del perfil de Post-Processing
        if (postProcessProfile.TryGetSettings(out colorGrading))
        {
            // Guardar los valores iniciales
            initialSaturation = colorGrading.saturation.value;
            initialContrast = colorGrading.contrast.value;
        }
        else
        {
            Debug.LogError("No se encontraron configuraciones de ColorGrading en el perfil de Post-Processing. Asegúrate de que estén configuradas.");
        }

        // Obtener las configuraciones de ColorGrading del perfil de Post-Processing
        if (postProcessProfile.TryGetSettings(out ambientOcclusion))
        {
            // Guardar los valores iniciales
            initialAOIntensity = ambientOcclusion.intensity.value;
            initialthicknessModifier = ambientOcclusion.thicknessModifier.value;
            initialcolor = ambientOcclusion.color.value;
        }
        else
        {
            Debug.LogError("No se encontraron configuraciones de ambientOcclusion en el perfil de Post-Processing. Asegúrate de que estén configuradas.");
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtener todas las luces en la escena
        Light[] lights = FindObjectsOfType<Light>();

        Color targetcolor = Random.ColorHSV(0f, 0.000001f, 0f, 0.000001f, 0f, 0.000001f);

        // Restringir el valor de pitchInicial a un rango válido
        pitchInicial = Mathf.Clamp(pitchInicial, 0.1f, 3.0f);
        audioSource.pitch = pitchInicial;

    }

    // Update is called once per frame
    void Update()
    {
        // Si el movimiento se ha iniciado
        if (movimientoIniciado)
        {
            Debug.Log("acercandose al pilar negro");

            // Actualizar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            // Calcular el valor "t" para la interpolación
            float t = Mathf.Clamp01(tiempoPasado / duracionMovimiento);

            // Interpolar la posición del jugador hacia la posición del objeto mesh
            transform.position = Vector3.Lerp(posicionInicialJugador, posicionFinalJugador, t);

            // Cambiar gradualmente la exposición del skybox
            if (skyboxMaterial != null)
            {
                // Cambia gradualmente la exposición del skybox
                float newExposure = Mathf.Lerp(initialExposure, targetExposure, t);
                RenderSettings.skybox.SetFloat("_Exposure", newExposure);

                float newSunSize = Mathf.Lerp(initialSunSize, targetSunSize, t);
                RenderSettings.skybox.SetFloat("_SunSize", newSunSize);

            }


            if (manosMaterial != null)
            {
                // Cambia gradualmente la exposición de las manos
                manosMaterial.color = Color.Lerp(manosInicial, targetcolor, t);

            }


            // Cambiar gradualmente la intensidad de la Directional Light
            if (directionalLight != null)
            {
                float newIntensity = Mathf.Lerp(initialIntensity, targetIntensity, t);
                directionalLight.intensity = newIntensity;
            }


            if (audioSourceObjeto != null)
            {
                // Obtiene el componente AudioSource del objeto
                audioSource = audioSourceObjeto.GetComponent<AudioSource>();

                if (audioSource != null)
                {
                    // El AudioSource se encontró y la referencia es válida
                    // Interpolar el pitch del AudioSource hacia el pitch final
                    audioSource.pitch = Mathf.Lerp(pitchInicial, pitchFinal, t);
                }
                else
                {
                    Debug.LogError("No se encontró un componente AudioSource en el objeto " + audioSourceObjeto.name);
                }
            }
            else
            {
                Debug.LogError("No se encontró un objeto con el nombre 'PilarNegro' en la escena.");
            }

            // Si el tiempo ha alcanzado la duración, detener el movimiento
            if (t >= 1.0f)
            {
                Debug.Log("se resuelve acercamiento");
                tiempoPasado = 0.0f; // Reiniciar el tiempo
                movimientoIniciado = false; // Detener el movimiento
               SceneManager.LoadScene(Menu);
            }


            if (colorGrading != null)
            {

                // Interpolar los valores
                colorGrading.saturation.value = Mathf.Lerp(initialSaturation, targetSaturation, t);
                colorGrading.contrast.value = Mathf.Lerp(initialContrast, targetContrast, t);


            }
            ;
            if (ambientOcclusion != null)
            {
                                   // Interpolar los valores
                ambientOcclusion.intensity.value = Mathf.Lerp(initialAOIntensity, targetAOIntensity, t);
                ambientOcclusion.thicknessModifier.value = Mathf.Lerp(initialthicknessModifier, targetthicknessModifier, t);
                ambientOcclusion.color.value = Color.Lerp(initialcolor, targetcolor, t);
            }

        }
    }
}