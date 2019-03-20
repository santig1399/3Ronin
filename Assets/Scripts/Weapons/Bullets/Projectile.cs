using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 10;
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player Must Take Damage");
                hitInfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                
            }
            DestroyProjectile();

        }
    }


    public virtual void DestroyProjectile() {
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        Debug.Log("impact effect must be instatiate");
        Destroy(gameObject);
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
