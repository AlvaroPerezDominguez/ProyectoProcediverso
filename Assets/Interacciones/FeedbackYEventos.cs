using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackYEventos : MonoBehaviour
{
    public List<ModificacionPitch> objetosPitch; // Lista de objetos BrilloPeriferia a afectar


    public SaturadorManos saturadorManos;

    // Start is called before the first frame update
    void Start()
    {

        // Buscar todos los objetos en la escena que tengan el componente ModificacionPitch adjunto
        ModificacionPitch[] modificacionPitch = FindObjectsOfType<ModificacionPitch>();
        // Agregar los objetos encontrados a la lista objetosPitch
        objetosPitch.AddRange(modificacionPitch);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DetonarEventos()
    {

        Debug.Log("Detonando Eventos");


        if (saturadorManos != null)
        {
            Debug.Log("llamando a saturadorManos");
            saturadorManos.AumentarSaturacionManos();

        }
        else
        {
            Debug.LogWarning("La referencia a la lista de objetos saturadorManos no está asignada en el Inspector.");
        }



        // Asegúrate de que la referencia a la lista de objetos BrilloPeriferia esté asignada en el Inspector
        if (objetosPitch != null)
        {
            // Llama a la función AumentarIntensidad en cada objeto BrilloPeriferia de la lista
            foreach (ModificacionPitch modificacionPitch in objetosPitch)
            {
                Debug.Log("Llamando a modificar pitch");

               modificacionPitch.ModifyPitch();
            }
        }
        else
        {
            Debug.LogWarning("La referencia a la lista de objetos ModificacionPitch no está asignada en el Inspector.");
        }
        
    }
}
