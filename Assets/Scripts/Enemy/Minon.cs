using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minon : Enemy
{
    private Rigidbody2D rb;
    private Transform target;
    private Animator anim;
    private float timeBtwAttacks;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    void Update()
    {
        if (target != null) {
            FollowPlayer();
        }
    }
    public override void FollowPlayer() {

        
        Vector2 dir = (target.position - transform.position ).normalized;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < visiusRadius)
        {
            rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
            anim.SetBool("Walking", true);
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            anim.SetBool("Walking", false);

            if (timeBtwAttacks <= 0)
            {
                anim.SetTrigger("Attacking");
                anim.SetFloat("movX", dir.x);
                anim.SetFloat("movY", dir.y);
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            rb.MovePosition(rb.position + dir * -speed * Time.deltaTime);
            anim.SetBool("Walking", true);
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
        }
        else if (Vector2.Distance(transform.position, target.position) > visiusRadius) {
            anim.SetBool("Walking", false);
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
        }
    }

}
