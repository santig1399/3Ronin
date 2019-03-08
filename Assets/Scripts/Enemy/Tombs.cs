using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombs : MonoBehaviour
{
    
    public float startTimeBtwShoots;
    private float timeBtwShoots;
    public int damage;
    
   //public GameObject impactEffect; // si hay?
    public LineRenderer lineRenderer;
    public Transform shootOrigin;
    
    
    
    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    void Update()
    {
   
        if (timeBtwShoots <= 0)
        {
            lineRenderer.enabled = false;
            timeBtwShoots = startTimeBtwShoots;
        }
        else if (timeBtwShoots > 0){
            TombShoot();
            timeBtwShoots -= Time.deltaTime;
        }
        
    }
    
    public void TombShoot() {

        RaycastHit2D hit = Physics2D.Raycast(shootOrigin.position, shootOrigin.up);
        if (hit)
        {
            PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("playerHealth taking damage");
            }
            //Instantiate(impactEffect, hit.point, Quaternion.identity);
            Debug.Log("imact effect");

            lineRenderer.SetPosition(0, shootOrigin.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else {
            lineRenderer.SetPosition(0, shootOrigin.position);
            lineRenderer.SetPosition(1, shootOrigin.position + shootOrigin.up * 100);
            //aunque se supone que debe impactar si o si algo.
        }

        lineRenderer.enabled = true;
        
    }


}
