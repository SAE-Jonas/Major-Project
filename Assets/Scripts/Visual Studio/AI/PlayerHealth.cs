using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerStartHealth;
    public int PlayerGameHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGameHealth = PlayerStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGameHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DamageRecieved(int HealthReduced)
    {
        PlayerGameHealth -= HealthReduced;
    }
}
