using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerCamera : MonoBehaviour
{

    public float cameraSpeed = 100f;
    public float xRotation = 0f;
    public Transform player;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float cameraX = Input.GetAxis("CameraMovementX") * cameraSpeed * Time.deltaTime;
        float cameraY = Input.GetAxis("CameraMovementY") * cameraSpeed * Time.deltaTime;

        xRotation -= cameraY;
        xRotation = Mathf.Clamp(xRotation, -15f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * cameraX);
    }
}
