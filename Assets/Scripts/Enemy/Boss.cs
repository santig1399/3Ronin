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

    private Animator anim;
    private float timeBtwAttacks;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        randomSpot = Random.Range(0, objetives.Length);
        timeBtwAttacks = startTimeBtwAttacks;
        
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
            Vector3 dir = (t.position - transform.position);
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            if (timeBtwAttacks <= 0)
            {
                StartCoroutine(RangeAttack());
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;

            }
            base.FollowPlayer();
        }
       

    }
    IEnumerator  RangeAttack() {

        Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    
      
}
