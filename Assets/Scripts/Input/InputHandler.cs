
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Movement movement;
    public Joystick joystick;
    private float x, y;
    private Animator anim;
    

    void Start()
    {
        movement = FindObjectOfType<Movement>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Player_Attack");
        
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movement.Move(x, y);

        if (Input.GetMouseButtonDown(0))
        {
            if (!attacking)
            {
                 movement.Attack();
                       
            }
          
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
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
