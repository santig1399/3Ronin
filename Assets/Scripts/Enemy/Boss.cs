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
        Transform player = Target();
        Vector3 dir = (player.position - transform.position).normalized;
        Vector3 dirObjetives = (objetives[randomSpot].position-transform.position).normalized;
        if (Vector2.Distance(transform.position, player.position) > visiusRadius)
        {  
            transform.position = Vector2.MoveTowards(transform.position, objetives[randomSpot].position, speed * Time.deltaTime);

            anim.SetFloat("movX",dirObjetives.x);
            anim.SetFloat("movY", dirObjetives.y);
            //anim.SetBool("Walking",true);

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
            
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            //anim.SetBool("Walking",true);
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
        
    }
    
      
}
