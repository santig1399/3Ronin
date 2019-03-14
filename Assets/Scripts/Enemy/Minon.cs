using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minon : Enemy
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        FollowPlayer();
    }
    public override void FollowPlayer() {

        Transform t = Target();
        Vector2 dir = (t.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, t.position) > stoppingDistance && Vector2.Distance(transform.position, t.position) < visiusRadius)
        {
            rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, t.position) < stoppingDistance && Vector2.Distance(transform.position, t.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, t.position) < retreatDistance)
        {
            rb.MovePosition(rb.position + dir * -speed * Time.deltaTime);
        }
    }


}
