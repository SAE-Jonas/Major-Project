using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneCount : MonoBehaviour
{
    public GameObject RuneUI;

    // Start is called before the first frame update
    void Start()
    {
        RuneUI = GameObject.Find("RuneNumber");
    }

    // Update is called once per frame
    void Update()
    {
        RuneUI.GetComponent<Text>().text = CollectRune.objects.ToString();

        if(CollectRune.objects == 0)
        {
            RuneUI.GetComponent<Text>().text = "All objects collected";
        }
    }
}