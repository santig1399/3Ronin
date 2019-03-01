using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombs : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float startTimeBtwShoots;
    private float timeBtwShoots;
    
    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        timeBtwShoots -= Time.deltaTime;
        if (hit.transform.CompareTag("Player") && timeBtwShoots<=0)
        {
            Debug.Log("bullt Must be Instantiate");
            
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            timeBtwShoots = startTimeBtwShoots;
        }       
            
    }
   


}
