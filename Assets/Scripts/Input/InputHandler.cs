using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Movement movement;
    public Joystick joystick;

    void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

   
    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        movement.Move(x, y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            movement.Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {
            movement.SpecialAttack();
        }
#elif UNITY_ANDROID || UNITY_IPHONE
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        movement.Move(x, y);
#endif
    }
}
