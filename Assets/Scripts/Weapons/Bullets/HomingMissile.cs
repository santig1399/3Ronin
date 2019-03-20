using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed;
    public float rotatingSpeed = 200;
    private GameObject target;
    public float startTimeToExplode;
    private float timeToExplode;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");
        timeToExplode = startTimeToExplode;
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null) {

            timeToExplode -= Time.deltaTime;
            Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

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
    public void DestroyProjectile()

    {
            Debug.Log("Impact effect must be instantiate");
            Destroy(this.gameObject);
    }
}
