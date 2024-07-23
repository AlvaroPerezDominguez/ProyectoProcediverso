using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaReset : MonoBehaviour
{
    public Transform playerTransform; // Referencia al Transform del jugador
    public Vector3 resetPosition = new Vector3(0f, 12f, 0f); // Posición a la que se reiniciará el jugador
    public float resetThreshold = -0.195f; // Valor de posición en Y por debajo del cual se activará el reinicio

    private bool hasReset = false; // Variable para evitar el reinicio continuo mientras el jugador esté en posición de reinicio

    private void Update()
    {
        // Si el jugador está por debajo de la posición Y del resetThreshold y aún no ha sido reiniciado, procedemos al reinicio
        if (playerTransform.position.y <= resetThreshold && !hasReset)
        {
            // Cambiamos la posición del jugador a la posición de reinicio
            playerTransform.position = resetPosition;

            // Restablecer la verticalSpeed usando CaidaInicial
            CaidaInicial caidaInicial = playerTransform.GetComponent<CaidaInicial>();
            if (caidaInicial != null)
            {
                caidaInicial.ResetVerticalSpeed();
            }

            hasReset = true; // Marcamos que el jugador ya ha sido reiniciado para evitar un reinicio continuo
        }

        // Si el jugador vuelve a estar por encima de la posición Y del resetThreshold, reseteamos la variable hasReset para permitir otro reinicio si es necesario
        if (playerTransform.position.y > resetThreshold)
        {
            hasReset = false;
        }
    }
}