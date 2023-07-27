using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gameinput : MonoBehaviour
{

    public Joystick joystick;
    Vector3 jdir;
    Vector2 dir = Vector2.zero;
    Vector3 retdir;
    //void Start()
    //{

    //}
    public event EventHandler onInteractaction;
    Playerinput p_input;
    private void Awake()
    {
        p_input = new Playerinput();
        p_input.player.Enable();
        p_input.player.interact.performed += Interact_performed; ;
    }

     void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (onInteractaction != null)
            onInteractaction(this, EventArgs.Empty);
       // throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        dir = p_input.player.Move.ReadValue<Vector2>();
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (joystick.Horizontal >= 0.2 || joystick.Horizontal <= -0.2)
                dir.x = joystick.Horizontal;
            if(joystick.Vertical >= 0.2 || joystick.Vertical <= -0.2)
                dir.y = joystick.Vertical;
        }
        else
            dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
            dir.x = dir.x - 1;
        if (Input.GetKey(KeyCode.D))
            dir.x = dir.x + 1;
        if (Input.GetKey(KeyCode.W))
            dir.y = dir.y + 1;
        if (Input.GetKey(KeyCode.S))
            dir.y = dir.y - 1;



    }

    public Vector3 userinput()
    {
        retdir.x = dir.x;
        retdir.z = dir.y;
        retdir = retdir.normalized;
        return retdir;
    }

}
