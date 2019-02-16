using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float stoppingDistance;
    public float speed;
    public float timeBtwAttacks;
    public float visiusRadius;

    
    public  GameObject bulletPrefab;
    private Rigidbody2D rb;
    private Animator anim;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    public virtual void FollowPlayer() {
        //Vector2 target = Target();
        //if (Vector2.Distance(rb.position, target) > stoppingDistance)
        //{
        //    rb.MovePosition(rb.position + target * speed * Time.deltaTime);
        //}
        Transform t = Targ();
        
        
        if (Vector2.Distance(transform.position, t.position) > stoppingDistance && Vector2.Distance(transform.position, t.position)<visiusRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
            
        }
        
    }
    
    public Vector2 Target() {
        Vector2 targ = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().position;
        return targ;
    }
    public Transform Targ() {
        Transform targ = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        return targ;
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        Gizmos.DrawWireSphere(transform.position, visiusRadius);

    }


}
