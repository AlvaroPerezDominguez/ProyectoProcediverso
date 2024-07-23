using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    // Variables de movimiento y sensibilidad
    [Range(1f, 5f)]
    public float MovementSpeed = 1f;
    [Range(1, 500f)]
    public float LookSensitivity = 200f;
    [Range(1, 500f)]
    public float MouseSensitivity = 3;
    [Range(1, 100f)]
    public float JumpStrength = 2f;

    // Referencias y variables privadas
    private CharacterController characterController;
   // private Transform cameraTransform;
   // private float cameraTilt = 0f;
    public float verticalSpeed = 0f; // Controla la velocidad vertical del jugador (salto y gravedad)
    private float timeInAir = 0f; // Tiempo que el jugador ha estado en el aire después del último salto
    private bool jumpLocked = false; // Evita múltiples saltos mientras el jugador está en el aire

    public LayerMask CollisionLayers;

    // Método llamado cuando se habilita el componente
    void OnEnable()
    {
        // Obtener referencias a CharacterController y la cámara
        this.characterController = this.GetComponent<CharacterController>();
     //   this.cameraTransform = this.GetComponentInChildren<Camera>().transform;
       // this.cameraTilt = this.cameraTransform.localRotation.eulerAngles.x;
    }

    // Método que se ejecuta en cada frame
    void Update()
    {
        // Comprobar si el jugador toca el suelo
        bool touchesGround = this.onGround();

        // Multiplicador de velocidad si el jugador está corriendo
        float runMultiplier = 1f + 2f * Input.GetAxis("Run");

        /* Movimiento horizontal del jugador
       Vector3 movementVector = this.transform.forward * Input.GetAxis("Move Y") + this.transform.right * Input.GetAxis("Move X");

        // Normalizar el vector de movimiento para evitar movimientos diagonales demasiado rápidos
        if (movementVector.sqrMagnitude > 1)
        {
            movementVector.Normalize();
        }

        // Mover al jugador en función de las entradas de movimiento, velocidad y correr
       this.characterController.Move(movementVector * Time.deltaTime * this.MovementSpeed * runMultiplier);

        // Control de la cámara: rotación horizontal y vertical
        float verticalMovement = this.transform.position.y;

        this.transform.localRotation = Quaternion.AngleAxis(Input.GetAxis("Mouse Look X") * this.MouseSensitivity + Input.GetAxis("Look X") * this.LookSensitivity * Time.deltaTime, Vector3.up) * this.transform.rotation;
        this.cameraTilt = Mathf.Clamp(this.cameraTilt - Input.GetAxis("Mouse Look Y") * this.MouseSensitivity - Input.GetAxis("Look Y") * this.LookSensitivity * Time.deltaTime, -90f, 90f);
        this.cameraTransform.localRotation = Quaternion.AngleAxis(this.cameraTilt, Vector3.right);*/
        
        // Control del salto y gravedad
        if (touchesGround)
        {
            this.timeInAir = 0;
        }
        else
        {
            this.timeInAir += Time.deltaTime;
        }

        if (touchesGround && this.verticalSpeed < 0)
        {
            this.verticalSpeed = 0;
        }
        else
        {
            this.verticalSpeed -= 9.18f * Time.deltaTime;
        }

        // Desbloquear el salto si el jugador no mantiene presionado el botón de salto
        if (Input.GetAxisRaw("Jump") < 0.1f)
        {
            this.jumpLocked = false;
        }

        // Saltar si el jugador está en el suelo y presiona el botón de salto
        if (!this.jumpLocked && this.timeInAir < 0.5f && Input.GetAxisRaw("Jump") > 0.1f)
        {
            this.timeInAir = 0.5f;
            this.verticalSpeed = this.JumpStrength;
            this.jumpLocked = true;
        }

        // Controlar el jetpack (si el jugador lo tiene)
        if (Input.GetAxisRaw("Jetpack") > 0.1f)
        {
            this.verticalSpeed = 2f;
        }

        // Aplicar movimiento vertical (salto y gravedad) al CharacterController
        this.characterController.Move(Vector3.up * Time.deltaTime * this.verticalSpeed);
    }

    // Método para habilitar el controlador
    public void Enable()
    {
        this.verticalSpeed = 0;
    }

    // Método para comprobar si el jugador está en el suelo
    private bool onGround()
    {
        var ray = new Ray(this.transform.position, Vector3.down);
        return Physics.SphereCast(ray, this.characterController.radius, this.characterController.height / 2 - this.characterController.radius + 0.1f, this.CollisionLayers);
    }
}