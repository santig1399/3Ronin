using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minon : Enemy
{
    private Rigidbody2D rb;
    private Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (target != null) {
            FollowPlayer();
        }
        
    }
    public override void FollowPlayer() {

        
        Vector2 dir = (target.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < visiusRadius)
        {
            rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            rb.MovePosition(rb.position + dir * -speed * Time.deltaTime);
        }
    }


}
