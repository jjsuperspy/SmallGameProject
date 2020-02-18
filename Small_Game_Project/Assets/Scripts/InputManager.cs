using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    //
    public KeyCode actionKeyOneKey = KeyCode.J;
    public KeyCode actionKeyTwoKey = KeyCode.K;
    public KeyCode actionKeyThreeKey = KeyCode.L;
    public KeyCode actionKeyFourKey = KeyCode.Semicolon;
    //
    public KeyCode cameraRotLeftKey = KeyCode.Q;
    public KeyCode cameraRotRightKey = KeyCode.E;
    //
    public KeyCode menuOneKye = KeyCode.Tab;
    public KeyCode menuTwoKye = KeyCode.Escape;
    //
    public bool moveUp = false;
    public bool moveDown = false;
    public bool moveLeft = false;
    public bool moveRight = false;
    //
    public bool actionKeyOneDown = false;
    public bool actionKeyTwoDown = false;
    public bool actionKeyThreeDown = false;
    public bool actionKeyFourDown = false;
    //
    public bool cameraRotLeftDown = false;
    public bool cameraRotRightDown = false;
    //
    public bool menuOneDown = false;
    public bool menuTwoDown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputKeys();
    }

    void UpdateInputKeys()
    {

        moveUp = Input.GetKey(moveUpKey);
        moveDown = Input.GetKey(moveDownKey);
        moveLeft = Input.GetKey(moveLeftKey);
        moveRight = Input.GetKey(moveRightKey);
        //
        actionKeyOneDown = Input.GetKeyDown(actionKeyOneKey);
        actionKeyTwoDown = Input.GetKeyDown(actionKeyTwoKey);
        actionKeyThreeDown = Input.GetKeyDown(actionKeyThreeKey);
        actionKeyFourDown = Input.GetKeyDown(actionKeyFourKey);
        //
        cameraRotLeftDown = Input.GetKey(cameraRotLeftKey);
        cameraRotRightDown = Input.GetKey(cameraRotRightKey);
        //
        menuOneDown = Input.GetKeyDown(menuOneKye);
        menuTwoDown = Input.GetKeyDown(menuTwoKye);

    }

}
