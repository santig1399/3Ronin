using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingBullet : Projectile
{    
    void Update()
    {
        Shoot();
    }
    public override void Shoot()
    {
        speed = Mathf.Clamp(speed, 1, 1);
        transform.Rotate(0f, 0f, -1f);
        base.Shoot();
        
    }
}
