using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minon : Enemy
{
    private Rigidbody2D rb;
    private Transform target;
    private Animator anim;
    private float timeBtwAttacks;
    private CircleCollider2D attackCollider;

    public enum MinionType {ashigaru, sword };
    public MinionType minionType;

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
        

        Vector3 dir = (target.position - transform.position );
        dir = dir.normalized;

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < visiusRadius)
        {
            transform.Translate(dir * speed * Time.deltaTime);
          //  rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
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
                if (minionType == MinionType.sword)
                {
                    FindObjectOfType<AudioManager>().Play("MinionAttack");
                }
                else if (minionType == MinionType.ashigaru) {
                    FindObjectOfType<AudioManager>().Play("AshigaruAttack");
                }
               
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.Translate(dir * -speed * Time.deltaTime);
            // rb.MovePosition(rb.position + dir * -speed * Time.deltaTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            FindObjectOfType<PlayerHealth>().TakeDamage(damage);
        }
    }

}
