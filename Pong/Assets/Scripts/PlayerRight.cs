using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject player;
    public GameObject ball;

    void Start()
    {
        player = gameObject;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (ball.transform.localPosition.x < player.transform.localPosition.x)
            {
                NewDirection();
            }
        }
    }

    public void NewDirection()
    {
        float direction = ball.GetComponent<BallMovement>().direction;
        float previousDirection = direction;

        if (direction > 3 * Mathf.PI / 2)
        {
            direction = Mathf.PI + (Mathf.PI * 2 - direction);
            if (direction == Mathf.PI * 2)
            {
                direction = 0;
            }
        }
        else
        {
            direction = Mathf.PI - direction;
        }

        if (ball.transform.localPosition.z > player.transform.localPosition.z + player.transform.localScale.z / 3)
        {
            if (direction <= Mathf.PI)
            {
                direction -= Mathf.PI / 12;
                ball.GetComponent<BallMovement>().directionChanges += 1;
            }
            else
            {
                direction = previousDirection + Mathf.PI;
            }
            NewSpeed();
        }
        else if (ball.transform.localPosition.z < player.transform.localPosition.z - player.transform.localScale.z / 3)
        {
            if (direction >= Mathf.PI)
            {
                direction += Mathf.PI / 12;
                ball.GetComponent<BallMovement>().directionChanges += 1;
            }
            else
            {
                direction = previousDirection + Mathf.PI;
            }
            NewSpeed();
        } else
        {
            if (ball.GetComponent<BallMovement>().directionChanges > 0)
            {
                if (direction <= Mathf.PI)
                {
                    direction += Mathf.PI / 12;
                }
                else
                {
                    direction -= Mathf.PI / 12;
                }
                ball.GetComponent<BallMovement>().directionChanges -= 1;
            }
        }

        if (direction >= Mathf.PI * 2)
        {
            direction -= Mathf.PI * 2;
        } else if (direction < 0)
        {
            direction += Mathf.PI * 2;
        }

        ball.GetComponent<BallMovement>().direction = direction;
    }

    public void NewSpeed()
    {
        if (ball.GetComponent<BallMovement>().speed <= 17.0f)
        {
            ball.GetComponent<BallMovement>().speed += 1.0f;
        }
    }
}
