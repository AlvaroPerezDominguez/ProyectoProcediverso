using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleActiveObject : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Puedes poner c�digo de inicializaci�n aqu� si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes poner c�digo de actualizaci�n aqu� si es necesario
    }
}