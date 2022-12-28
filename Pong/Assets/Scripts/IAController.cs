using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject ia;
    public GameObject ball;

    [Header("Variables")]
    public int level = 0;
    public float speed = 10.0f;

    int direction = 0;
    float newPosition = 0.0f;

    void Start()
    {
        ia = gameObject;
        ball = GameObject.FindGameObjectWithTag("Ball");

        Level();
    }

    void Update()
    {
        //NewPosition();
        LevelEasy();
    }

    public void Level()
    {
        if (level == 0)
        {
            speed = 7.0f;
        } else if (level == 1)
        {
            speed = 10.0f;
        } else
        {
            speed = 12.0f;
        }
    }

    public void NewPosition()
    {
        if (ia.transform.localPosition.z < ball.transform.localPosition.z)
        {
            direction = 1;
        } else if (ia.transform.localPosition.z > ball.transform.localPosition.z)
        {
            direction = -1;
        } else
        {
            direction = 0;
        }

        newPosition = ia.transform.localPosition.z + direction * Time.deltaTime * speed;
        if (-1 * direction * newPosition <= -7.9f)
        {
            newPosition = direction * 7.9f;
        }

        ia.transform.localPosition = new Vector3(ia.transform.localPosition.x, 0.0f, newPosition);
    }

    public void LevelEasy()
    {
        if (ball.transform.localPosition.z > ia.transform.localPosition.z + ia.transform.localScale.z / 4)
        {
            direction = 1;
        } else if (ball.transform.localPosition.z < ia.transform.localPosition.z - ia.transform.localScale.z / 4)
        {
            direction = -1;
        } else if (ball.transform.localPosition.z < ia.transform.localPosition.z + ia.transform.localScale.z / 4 && ball.transform.localPosition.z > ia.transform.localPosition.z - ia.transform.localScale.z / 4)
        {
            direction = 0;
        }

        newPosition = ia.transform.localPosition.z + direction * Time.deltaTime * speed;
        if (-1 * direction * newPosition <= -7.9f)
        {
            newPosition = direction * 7.9f;
        }

        ia.transform.localPosition = new Vector3(ia.transform.localPosition.x, 0.0f, newPosition);
    }

    public void LevelNormal()
    {

    }

    public void LevelHard()
    {

    }
}
