using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }    
    }

    public void HurtGhost(int damage)
    {
        currentHealth -= damage;
    }
}
