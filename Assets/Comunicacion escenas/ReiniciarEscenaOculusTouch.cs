using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReiniciarEscenaOculusTouch : MonoBehaviour
{
    public InputActionReference reiniciarEscenaReference = null;

    private void Awake()
    {
        // Asegúrate de manejar el evento "performed" en lugar de "started"
        reiniciarEscenaReference.action.performed += ReiniciarScene;
    }

    private void OnDestroy()
    {
        reiniciarEscenaReference.action.performed -= ReiniciarScene;
    }

    private void ReiniciarScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
