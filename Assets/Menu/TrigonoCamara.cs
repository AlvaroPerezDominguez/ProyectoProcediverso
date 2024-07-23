using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class TrigonoCamara : MonoBehaviour
{
    // TrigonoCamara variables
    public Transform target;
    public float hypotenuseLength = 5f;
    public float angle = 30f;

    // FreeCameraController variables
    public float LookSensitivity = 200f;
    public float MouseSensitivity = 3;

    private Transform cameraTransform;
    private float cameraTilt = 0f;

    private void Start()
    {
        // TrigonoCamara Start
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    
        // FreeCameraController Start
        cameraTransform = GetComponentInChildren<Camera>().transform;
        cameraTilt = cameraTransform.localRotation.eulerAngles.x;
    }

    private void Update()
    {
        // TrigonoCamara Update
        Vector3 cameraPosition = target.position + new Vector3(0f,
            Mathf.Sin(angle * Mathf.Deg2Rad) * hypotenuseLength,
            Mathf.Cos(angle * Mathf.Deg2Rad) * hypotenuseLength
        );
        transform.position = cameraPosition;

        // FreeCameraController Update
        
        transform.localRotation = Quaternion.AngleAxis(Input.GetAxis("Mouse Look X") * MouseSensitivity + Input.GetAxis("Look X") * LookSensitivity * Time.deltaTime, Vector3.up) * transform.rotation;
        cameraTilt = Mathf.Clamp(cameraTilt - Input.GetAxis("Mouse Look Y") * MouseSensitivity - Input.GetAxis("Look Y") * LookSensitivity * Time.deltaTime, -90f, 90f);
       cameraTransform.localRotation = Quaternion.AngleAxis(cameraTilt, Vector3.right);

    }

}