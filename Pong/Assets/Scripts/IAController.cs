using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject ia;
    public GameObject ball;

    [Header("Variables")]
    public int level;
    public float speed = 10.0f;

    int direction = 0;
    float newPosition = 0.0f;

    void Start()
    {
        level = MapSelection.levelIA;
        ia = gameObject;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void FixedUpdate()
    {
        if (level == 0)
        {
            LevelEasy();
        } else if (level == 1)
        {
            LevelNormal();
        } else if (level == 2)
        {
            LevelNormal();
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
        if (ball.transform.localPosition.z > ia.transform.localPosition.z + ia.transform.localScale.z / 8)
        {
            direction = 1;
        }
        else if (ball.transform.localPosition.z < ia.transform.localPosition.z - ia.transform.localScale.z / 8)
        {
            direction = -1;
        }
        else if (ball.transform.localPosition.z < ia.transform.localPosition.z + ia.transform.localScale.z / 8 && ball.transform.localPosition.z > ia.transform.localPosition.z - ia.transform.localScale.z / 8)
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

    public void LevelHard()
    {

    }
}
