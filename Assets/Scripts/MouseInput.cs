using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    public Transform player;
    public float mouseSens = 200f;

    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    void Update()
    {
        float mouseXPos = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseYPos = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseYPos;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        player.Rotate(Vector3.up * mouseXPos);
    }
}
