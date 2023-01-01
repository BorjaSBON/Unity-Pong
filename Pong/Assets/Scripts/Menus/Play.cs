using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void PlayClassic()
    {
        MapSelection.mapType = "Classic";
    }

    public void PlayClassicPro()
    {
        MapSelection.mapType = "Classic Pro";
    }
}
