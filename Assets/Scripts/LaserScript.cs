using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject firePoint;

    private GameObject spawnedLaser;

    // Start is called before the first frame update
    void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        Disablelaser();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Enablelaser();
        }

        if(Input.GetMouseButton(0))
        {
            UpdateLaser();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Disablelaser();
        }
    }

    void Enablelaser()
    {
        spawnedLaser.SetActive(true);
    }

    void UpdateLaser()
    {
        if(firePoint != null)
        {
            spawnedLaser.transform.position = firePoint.transform.position;
        }    
    }

    void Disablelaser()
    {
        spawnedLaser.SetActive(false);
    }
}
