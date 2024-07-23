using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CambioEscenaOculusTouch : MonoBehaviour
{
    public InputActionReference changeSceneReference = null;

    private void Awake()
    {
        // Asegúrate de manejar el evento "performed" en lugar de "started"
        changeSceneReference.action.performed += ChangeScene;
    }

    private void OnDestroy()
    {
        changeSceneReference.action.performed -= ChangeScene;
    }

    private void ChangeScene(InputAction.CallbackContext context)
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cambiar a la escena opuesta
        string targetScene = (currentSceneName == "Game") ? "Menu" : "Game";
        SceneManager.LoadScene(targetScene);
    }

}