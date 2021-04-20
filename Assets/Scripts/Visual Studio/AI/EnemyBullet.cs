using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    public int BulletDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Ghost")
        {
            player.gameObject.GetComponent<PlayerHealth>().DamageRecieved(BulletDamage);
            Destroy(gameObject);
        }
    }
}
