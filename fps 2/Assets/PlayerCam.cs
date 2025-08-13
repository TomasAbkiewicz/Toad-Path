using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private Camera cam;
    private float defaultFov;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Guardamos referencia a la cámara
        cam = GetComponent<Camera>();
        if (cam != null)
            defaultFov = cam.fieldOfView;
    }

    private void Update()
    {
        // input del mouse 
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        // máximo de rotación 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotar la cámara y la orientación
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // Cambiar el FOV temporalmente
    public void DoFov(float newFov)
    {
        if (cam != null)
            cam.fieldOfView = newFov;
    }

    // Restaurar el FOV original
    public void ResetFov()
    {
        if (cam != null)
            cam.fieldOfView = defaultFov;
    }


}
