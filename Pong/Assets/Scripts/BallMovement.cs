using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject ball;
    public int previousWinner = 0;

    [Header("Goals")]
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;

    [Header("Borders")]
    public GameObject goal1;
    public GameObject goal2;
    public GameObject borderTop;
    public GameObject borderBottom;

    [Header("Variables")]
    public float speed = 7.0f;

    public float direction;
    public Vector3 newPosition;

    void Start()
    {
        ball = gameObject;        

        goal1 = GameObject.FindGameObjectWithTag("Goal 1");
        goal2 = GameObject.FindGameObjectWithTag("Goal 2");
        borderTop = GameObject.FindGameObjectWithTag("Border Top");
        borderBottom = GameObject.FindGameObjectWithTag("Border Bottom");

        StartGame();
    }

    void Update()
    {
        NewPosition();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Border Top"))
        {
            if (direction < Mathf.PI / 2 && direction < 0.0f)
            {
                direction = Mathf.PI * 2 - direction;
            } else
            {
                direction += Mathf.PI / 2;
            }
        } else if (collision.CompareTag("Border Bottom"))
        {
            if (direction > 3 * Mathf.PI / 2 && direction < Mathf.PI * 2)
            {
                direction = Mathf.PI * 2 - direction;
            } else
            {
                direction -= Mathf.PI / 2;
            }
        } else if (collision.CompareTag("Goal 1"))
        {
            int score2 = int.Parse(scorePlayer2.text) + 1;
            scorePlayer2.text = score2.ToString();

            previousWinner = 2;
            StartGame();
        } else if (collision.CompareTag("Goal 2"))
        {
            int score1 = int.Parse(scorePlayer1.text) + 1;
            scorePlayer1.text = score1.ToString();

            previousWinner = 1;
            StartGame();
        }
    }

    public void StartGame()
    {
        ball.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        float limitUp = 15.0f;
        float limitDown = -15.0f;

        if (previousWinner == 0)
        {
            previousWinner = Random.Range(1, 3);
        }

        direction = Random.Range(limitDown, limitUp);

        if (previousWinner == 1)
        {
            direction += 180.0f;
        }

        direction = direction * Mathf.PI / 180f;
    }

    public void NewPosition()
    {
        newPosition = new Vector3(ball.transform.localPosition.x + Mathf.Cos(direction) * Time.deltaTime * speed, 0.0f, ball.transform.localPosition.z + Mathf.Sin(direction) * Time.deltaTime * speed);
        ball.transform.localPosition = newPosition;
    }

    public void CheckBorders()
    {
        
    }
}
