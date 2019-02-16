using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minon : Enemy
{
    private float counter;
    private Rigidbody2D rb;
    private Vector2 mov;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }
    void Update()
    {
        FollowPlayer();
    }
    public override void FollowPlayer()
    {
        Vector2 t = Target();
        if (Vector2.Distance(rb.position, t) <= stoppingDistance)
        {
            counter -= Time.deltaTime;
            float x = Mathf.Cos(counter);
            float y = Mathf.Sin(counter);
            
            mov.Set(x, y);
            rb.MovePosition(rb.position + (mov * Time.deltaTime));
        }
        else {
            
            base.FollowPlayer();
        }
        
    }

}
