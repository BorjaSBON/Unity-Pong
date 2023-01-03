using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayer : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject secondPlayer;
    public int level;

    void Awake()
    {
        secondPlayer = gameObject;
        level = MapSelection.levelIA;

        if (level == 0)
        {
            secondPlayer.GetComponent<IAController>().speed = 7.0f;
        }
        else if (level == 1)
        {
            secondPlayer.GetComponent<IAController>().speed = 10.0f;
        }
        else if (level == 2)
        {
            secondPlayer.GetComponent<IAController>().speed = 12.0f;
        }
        else
        {
            secondPlayer.GetComponent<IAController>().enabled = false;
            secondPlayer.GetComponent<PlayerController>().enabled = true;
        }
    }
}
