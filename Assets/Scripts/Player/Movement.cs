using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    Vector2 mov;

    CircleCollider2D attackCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Move(x,y);
        Animations();
        
    }

    void Move(float x, float y) {
        mov.Set(x, y);
        mov = mov.normalized * Time.deltaTime * speed;
        rb.MovePosition(rb.position + mov);      
    }
    void Animations() {
        if (mov != Vector2.zero)
        {
            // set bool walking 
            print("walking animation");
        }
        else {
            //set bool walking to false
            print("idle animation");
        }
        
    }

   

}
