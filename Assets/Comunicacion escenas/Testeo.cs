using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Management;

public class Testeo : MonoBehaviour
{
    private bool isRestarting = false;
    private bool isChangingScene = false;
    private bool isQuitting = false;

    private float restartTimer = 0f;
    private float sceneChangeTimer = 0f;
    private float quitTimer = 0f;

    public float restartTimeThreshold = 1f; // Tiempo necesario para reiniciar la escena
    public float sceneChangeTimeThreshold = 1f; // Tiempo necesario para cambiar de escena
    public float quitTimeThreshold = 5f; // Tiempo necesario para cerrar la aplicación

    void Update()
    {


        // Reiniciar la escena al presionar la tecla R durante 3 segundos
        if (Input.GetKeyDown(KeyCode.R) || OVRInput.Get(OVRInput.Button.One))
        {
            RestartScene();
        }


        // Cambiar de escena al presionar la tecla T o Espacio
        if (SceneManager.GetActiveScene().name != "Game" && (Input.GetKeyDown(KeyCode.T) || OVRInput.Get(OVRInput.Button.Three)))
        {
            ChangeScene();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeScene();
        }
                
        // Cerrar la aplicación al presionar la tecla Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            QuitApplication();
        }
       
       void RestartScene()
       {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

      void ChangeScene()
      {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cambiar a la escena "Menu" si la escena actual es "Game", y viceversa
        if (currentSceneName == "Game")
        {
            SceneManager.LoadScene("Menu");
        }
        else if (currentSceneName == "Menu")
        {
            SceneManager.LoadScene("Game");
        }
      }

      void QuitApplication()
      {
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
        #endif
      }
    }
}