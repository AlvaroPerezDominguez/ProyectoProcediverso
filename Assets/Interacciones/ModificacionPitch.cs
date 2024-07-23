using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificacionPitch : MonoBehaviour
{

    public AudioSource pilarBlancoAudioSource;

    [Header("Rango de pitch inicial")]
    public float minPitch = 0.4f; // Límite inferior del pitch
    public float maxPitch = 0.75f; // Límite superior del pitch

    private float pitchModifier = 1.0f; // Valor inicial de modificación del pitch
    public float pitchValue = 1.0f; // Valor de pitch deseado

     // Start is called before the first frame update
     private void Start()
     {

        pitchModifier = Random.Range(1.25f, 1.3f);

        // Genera un valor aleatorio dentro del rango [minPitch, maxPitch]
        pitchValue = Random.Range(minPitch, maxPitch);

     }

    public void ModifyPitch()
    {
        Debug.Log("Modificando Pitch");

        // Aplica el valor de modificación del pitch
        pitchValue = pilarBlancoAudioSource.pitch * pitchModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Actualizar rotacion del cubo en el eje Y
        pilarBlancoAudioSource.pitch= pitchValue;
    }
}
