﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchStaff : MonoBehaviour
{
    public bool isFiring;

    public LaserProjectile projectile;
    public float projectileSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                LaserProjectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as LaserProjectile;
                newProjectile.speed = projectileSpeed;
            }
        }

        else
        {
            shotCounter = 0;
        }
    }
}
