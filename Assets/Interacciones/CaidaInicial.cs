using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CaidaInicial : MonoBehaviour
{
    public float initialVerticalSpeed = -20f;
    private bool isOnGround = false;
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        ResetVerticalSpeed();
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo
        isOnGround = OnGround();

        // Si el jugador está en el suelo y la velocidad vertical es negativa, restablecer la velocidad vertical
        if (isOnGround && GetVerticalSpeed() < 0)
        {
            SetVerticalSpeed(0f); // Restablecer la velocidad vertical a 0
        }

        // Aplicar la gravedad al CharacterController
        ApplyGravity();
    }

    private bool OnGround()
    {
        var ray = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(ray, characterController.radius, characterController.height / 2 - characterController.radius + 0.1f);
    }

    public void SetVerticalSpeed(float speed)
    {
        characterController.Move(Vector3.up * Time.deltaTime * speed);
    }

    public float GetVerticalSpeed()
    {
        return characterController.velocity.y;
    }

    public void ResetVerticalSpeed()
    {
        SetVerticalSpeed(initialVerticalSpeed);
    }

    private void ApplyGravity()
    {
        if (!isOnGround)
        {
            // Aplicar la gravedad si el jugador no está en el suelo
            characterController.Move(Vector3.up * Time.deltaTime * GetVerticalSpeed());
        }
    }
}