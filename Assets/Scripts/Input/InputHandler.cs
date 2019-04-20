
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Movement movement;
    public Joystick joystick;
    private float x, y;

    

    void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

   
    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movement.Move(x, y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            movement.Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {
            movement.SpecialAttack();
        }
#elif UNITY_ANDROID || UNITY_IPHONE
        if (joystick.Horizontal > 0.2 || joystick.Horizontal < -0.2)
        {
            x = joystick.Horizontal;
        }
        else { x = 0; }
        if (joystick.Vertical > 0.2 || joystick.Vertical <-0.2)
        {
            y = joystick.Vertical;
        }
        else { y = 0; }
        movement.Move(x, y);
#endif
    }
}
