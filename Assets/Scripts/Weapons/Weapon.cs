using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;

    public GameObject projectile;
    public Transform firePoint;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    
    //public Animator playerAnim;

    // Update is called once per frame
    void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(0);
        //bool attacking = stateInfo.IsName("Player_Attack");
        if (timeBtwShoots <= 0)
        {
            if (Input.GetMouseButton(0)/*&& !attacking*/)
            {
                print("shhoting");
                Instantiate(projectile, firePoint.position, transform.rotation);
                timeBtwShoots = startTimeBtwShoots; 
            }
            
        }
        else {
            timeBtwShoots -= Time.deltaTime;
        }       
	}

   
}
