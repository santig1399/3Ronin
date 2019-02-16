using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Transform [] objetives;
    public float startWaitTime;
    public float maxWaitTime;
    private float waitTime;  
    private int randomSpot;

    private void Start()
    {
        randomSpot = Random.Range(0, objetives.Length);
        
    }
    void Update()
    {
        
        FollowPlayer();
        
    }
    public override void FollowPlayer()
    {
        Transform t = Targ();
        if (Vector2.Distance(transform.position, t.position) > visiusRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetives[randomSpot].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, objetives[randomSpot].position) < 0.2f) {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, objetives.Length);
                    waitTime = Random.Range(startWaitTime,maxWaitTime);
                }
                else
                {
                     waitTime -= Time.deltaTime;
                }
            }
            

        }
        else {
            
            base.FollowPlayer();
        }
       

    }
    
      
}
