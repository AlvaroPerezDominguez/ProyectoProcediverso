using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{


    public void OnClick()
    {
        SceneManager.LoadScene("Game");  // Reemplaza "Game" con el nombre de tu escena "Game" en el Editor de Unity
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
