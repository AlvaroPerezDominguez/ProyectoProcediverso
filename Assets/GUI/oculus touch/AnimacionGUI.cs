using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionGUI : MonoBehaviour
{

    public float tiempoEjecucion = 5.0f; // Establece el tiempo deseado en el Inspector
    private bool funcionEjecutada = false;
    private float tiempoInicio;

    public Image m_Image;
        public Sprite[] m_SpriteArray;
    public float m_Speed = .02f;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;

    private int m_RepetitionCount = 0; // Agregamos un contador de repeticiones
    public int repeticionesObjetivo = 1;
    public Image imageComponent; // Arrastra el componente Image que deseas controlar aquí en el Inspector


    public void Func_PlayUIAnim()
    {
        IsDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void Func_StopUIAnim()
    {
        IsDone = true;
        StopCoroutine(Func_PlayAnimUI());
    }

    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            m_IndexSprite = 0;
            m_RepetitionCount++; // Incrementa el contador de repeticiones
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;

        if (IsDone == false)
        {
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        }

        if (m_RepetitionCount >= repeticionesObjetivo)
        {
            ToggleImage();
            ResetRepetitionCount();
            Func_StopUIAnim();
        }
    }


    // Agregamos una función para obtener el contador de repeticiones
    public int GetRepetitionCount()
    {
        return m_RepetitionCount;
    }

    // Restablecer el contador de repeticiones
    public void ResetRepetitionCount()
    {
        m_RepetitionCount = 0;
    }

    public void ToggleImage()
    {
        // Verifica si el componente Image está presente y es válido
        if (imageComponent != null)
        {
            // Alterna el estado activo o inactivo del componente Image
            imageComponent.enabled = !imageComponent.enabled;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        

        tiempoInicio = Time.time;

        // Asegúrate de que has asignado el componente Image en el Inspector
        if (imageComponent == null)
        {
            Debug.LogError("No se ha asignado el componente Image en el Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!funcionEjecutada)
        {
            if (Time.time - tiempoInicio >= tiempoEjecucion)
            {
                ToggleImage();
                Func_PlayUIAnim();
                
                funcionEjecutada = true;
            }
        }

    }
}
