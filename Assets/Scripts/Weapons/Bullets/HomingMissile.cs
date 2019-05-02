using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Projectile
{
    //public float speed;
    public float rotatingSpeed = 200;
    //private GameObject player;
    public float startTimeToExplode;
    private float timeToExplode;
    //public float distance;
    //public LayerMask whatIsSolid;
    //public int damage;
    
    Rigidbody2D rb;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeToExplode = startTimeToExplode;
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("HommingMisile");

    }

    void FixedUpdate()
    {
        Shoot();
    }
    public override void Shoot()
    {
        if (player != null)
        {

            timeToExplode -= Time.deltaTime;
            Vector2 point2Target = (Vector2)transform.position - (Vector2)player.position;

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("Player Must Take Damage");
                    hitInfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                    FindObjectOfType<AudioManager>().Play("PlayerHurt");


                }
                DestroyProjectile();

            }
            point2Target.Normalize();

            float value = Vector3.Cross(point2Target, transform.right).z;
            rb.angularVelocity = rotatingSpeed * value;
            rb.velocity = transform.right * speed;

            if (timeToExplode <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public override void DestroyProjectile()

    {
            Debug.Log("Impact effect must be instantiate");
            Destroy(this.gameObject);
    }
}
