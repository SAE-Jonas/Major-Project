using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRune : MonoBehaviour
{
    public static int objects = 0;

    void Awake()
    {
        objects++;
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Witch")
        {
            objects--;
            gameObject.SetActive(false);
        }

        if (player.gameObject.tag == "Ghost")
        {
            objects--;
            gameObject.SetActive(false);
        }
    }
}
