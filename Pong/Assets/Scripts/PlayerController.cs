using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject player;

    [Header("Variables")]
    public float speed = 10.0f;

    float newPosition = 0.0f;

    void Start()
    {
        player = gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            NewPosition(1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            NewPosition(-1);
        }
    }

    public void NewPosition(float direction)
    {
        newPosition = player.transform.localPosition.z + direction * Time.deltaTime * speed;
        if (-1 * direction * newPosition  <= -7.9f)
        {
            newPosition = direction * 7.9f;
        }

        player.transform.localPosition = new Vector3(player.transform.localPosition.x, 0.0f, newPosition);
    }
}
