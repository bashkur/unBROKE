using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool lockCursor;
    public float sensitivity = 20.0f;
    public Transform target, player;

    float pitch;
    float yaw;

    public float rotationSmoothTime = 0.14f;
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
        yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -40, 75);

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(pitch, yaw, 0);
        player.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
