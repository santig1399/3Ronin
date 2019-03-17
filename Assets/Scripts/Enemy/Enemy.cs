using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float stoppingDistance;
    public float retreatDistance;
    public float visiusRadius;
    public float speed;
    public float startTimeBtwAttacks;
    

    
    public  GameObject bulletPrefab;

    public virtual void FollowPlayer() {
        
       
        Transform t = Target();
        if (Vector2.Distance(transform.position, t.position) > stoppingDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, t.position) < stoppingDistance && Vector2.Distance(transform.position, t.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, t.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, t.position, -speed * Time.deltaTime);
        }
        
    }
    
   
    public Transform Target() {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        return target;
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        Gizmos.DrawWireSphere(transform.position, visiusRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, retreatDistance);

    }


}
