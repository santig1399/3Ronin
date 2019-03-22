﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }
    
    void Update()
    {
        if (player != null) {
            Shoot();
        }
        
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
