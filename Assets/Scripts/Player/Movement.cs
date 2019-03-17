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
    
   

    public void Move(float x, float y) {
        mov.Set(x, y);
        mov = mov.normalized * Time.deltaTime * speed;
        rb.MovePosition(rb.position + mov);
        Animations();
        
    }
    void Animations() {
        if (mov != Vector2.zero)
        {
            // set bool walking 
            //set animator floats movX-movY with values of mov.x and mov.y
            print("walking animation");
        }
        else {
            //set bool walking to false
            print("idle animation");
        }
        
    }
    public void Attack() {
     
        //Debug.Log("Attacking With Basic Attack");
    }
    public void SpecialAttack() {
        Debug.Log("Attacking With Special Attack");
    }

   

}
