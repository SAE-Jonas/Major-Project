using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public int damageToGive;

    public bool gem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime = Time.deltaTime;
        if (lifeTime <=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            other.gameObject.GetComponent<GhostHealth>().HurtGhost(damageToGive);

            if(!gem)
            {
                Destroy(gameObject);
            }
        }
    }
}
