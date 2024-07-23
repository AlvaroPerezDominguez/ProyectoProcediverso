using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchVisible : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Canvas canvasToToggle;

    // Update is called once per frame
    void Update()
    {
        // Detectar si se presionó el botón TAB
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Cambiar el estado de visibilidad del Canvas
            if (canvasToToggle != null)
            {
                canvasToToggle.enabled = !canvasToToggle.enabled;
            }
        }
    }
}
