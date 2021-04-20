using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRune : MonoBehaviour
{
    public static int objects = 0;
    public Player_Movement Witch;
    public Player_Movement Ghost;

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
            Witch.RunesCollected += 1;
        }

        if (player.gameObject.tag == "Ghost")
        {
            objects--;
            gameObject.SetActive(false);
            Ghost.RunesCollected += 1;
        }
    }
}
