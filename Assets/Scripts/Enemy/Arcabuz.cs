using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcabuz : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 dir;
    public float visiusRadius;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float offset;

    public float startTimeBtwShoots;
    private float timeBtwShoots;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwShoots = startTimeBtwShoots;
    }
    void Update()
    {
        FollowTarget();
    }

    public void FollowTarget() {
        if (Vector2.Distance(transform.position, target.position) < visiusRadius)
        {
            Vector3 dir = target.position - transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            Debug.Log("Rotating to: " + rotZ);

            if (timeBtwShoots <= 0)
            {
                Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
                timeBtwShoots = startTimeBtwShoots;
            }
            else {
                timeBtwShoots -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visiusRadius);

    }
}
