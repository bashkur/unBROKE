using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool lockCursor;
    public float sensitivity = 10;
    public Transform target, player;

    float pitch;
    float yaw;

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    public Vector3 currentRotation;

    void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -40, 85);

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(pitch, yaw, 0);
        player.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
