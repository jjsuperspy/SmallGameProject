using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    public Transform playerCamera;
    public Transform player;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Entered Trigger");
            camera1.enabled = false;
            camera2.enabled = true;

            playerCamera.GetComponent<PlayerCamera>().enabled = false;
            player.transform.forward = transform.forward;

        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited Trigger");
        camera1.enabled = true;
        camera2.enabled = false;

        playerCamera.GetComponent<PlayerCamera>().enabled = true;
    }
}
