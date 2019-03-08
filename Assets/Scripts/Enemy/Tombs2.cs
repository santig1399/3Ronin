using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombs2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float startTimeBtwShoots;
    private float timeBtwShoots;
    public Transform firePoint;

    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        timeBtwShoots -= Time.deltaTime;
        if (hit.transform.CompareTag("Player") && timeBtwShoots <= 0)
        {
            Debug.Log("bullt Must be Instantiate");

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timeBtwShoots = startTimeBtwShoots;
        }

    }
}
