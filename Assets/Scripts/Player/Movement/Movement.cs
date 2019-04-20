using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int damage;
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    Vector2 mov;
    public int cointest;
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
        Animations(x,y);
        
    }
    void Animations(float x, float y) {
        if (mov != Vector2.zero)
        {
            //Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            anim.SetBool("Walking", true);
            anim.SetFloat("movX", x);
            anim.SetFloat("movY", y);
           // print("walking animation");
        }
        else {
            anim.SetBool("Walking", false);
        }
        
    }
    public void Attack() {

        anim.SetTrigger("Attacking");
        Debug.Log("Attacking With Basic Attack");
    }
    public void SpecialAttack() {
        Debug.Log("Attacking With Special Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }



}
