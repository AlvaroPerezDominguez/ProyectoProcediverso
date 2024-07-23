using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public Transform cubeTransform;

   public float cubeRotationSpeed;

    [Header("Rango de velocidad de rotacion inicial")]
    public float minRotacion = 12f; // Valor mínimo de intensidad de rotacion
    public float maxRotacion = 34f; // Valor máximo de intensidad de rotacion

   

    void Start()
    {
        // Establece rotacion inicial dentro del rango definido
        cubeRotationSpeed = Random.Range(minRotacion, maxRotacion);
    }

    public void AumentarVelocidad()
    {
       // Debug.Log("Aumentando Velocidad de rotacion...");
        cubeRotationSpeed = cubeRotationSpeed * Random.Range(3f, 1.25f);

    }

    private void Update()
    {
        // Actualizar rotacion del cubo en el eje Y
        cubeTransform.Rotate(Vector3.up * cubeRotationSpeed * Time.deltaTime);         
    }
}