using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    public GameObject cameraPin;
    public GameObject orientationPin;
    public Rigidbody playerRbody;
    public PlayerState currentPlayerState = PlayerState.in_Character;    
    public float defaultCharacterMoveSpeed = 10f;
    public float cameraRotationValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManagePlayerControl();
    }

    void ManagePlayerControl()
    {
        if(currentPlayerState == PlayerState.in_Character)
        {
            ManagCameraRotation();
            ManageInCharacterMovemnt();
        }
        ResolveCameraRotation();
        ResolveCameraPosition();
    }

    private Vector3 currentCameraRotation = Vector3.zero;
    private float cameraRotLerpSpeed = 7f;

    void ManagCameraRotation()
    {
        if (inputManager.cameraRotLeftDown)
        {
            currentCameraRotation.y -= cameraRotationValue;
        }
        if (inputManager.cameraRotRightDown)
        {
            currentCameraRotation.y += cameraRotationValue;
        }
    }

    void ResolveCameraRotation()
    {
        orientationPin.transform.localRotation = Quaternion.LerpUnclamped(orientationPin.transform.localRotation, Quaternion.Euler(currentCameraRotation), Time.smoothDeltaTime * cameraRotLerpSpeed);
    }

    private float cameraFollowLerpSpeed = 7f;

    void ResolveCameraPosition()
    {
        cameraPin.transform.position = Vector3.LerpUnclamped(cameraPin.transform.position, playerRbody.position, Time.smoothDeltaTime * cameraFollowLerpSpeed);
    }

    void ManageInCharacterMovemnt()
    {

        Vector3 inputDir = Vector3.zero;

        if (inputManager.moveUp)
        {
            inputDir += orientationPin.transform.forward * defaultCharacterMoveSpeed;
        }
        if (inputManager.moveDown)
        {
            inputDir -= orientationPin.transform.forward * defaultCharacterMoveSpeed;
        }
        if (inputManager.moveLeft)
        {
            inputDir -= orientationPin.transform.right * defaultCharacterMoveSpeed;
        }
        if (inputManager.moveRight)
        {
            inputDir += orientationPin.transform.right * defaultCharacterMoveSpeed;
        }

        playerRbody.AddForce(inputDir * Time.smoothDeltaTime, ForceMode.VelocityChange);

    }

    public enum PlayerState
    {
        in_Character,
        in_Menu,
    }
}
