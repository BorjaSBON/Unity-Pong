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

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;

    [Header("Variables")]
    public float speed = 7.0f;

    public float direction;
    public Vector3 newPosition;
    public int directionChanges = 0;

    void Start()
    {
        ball = gameObject;        

        goal1 = GameObject.FindGameObjectWithTag("Goal 1");
        goal2 = GameObject.FindGameObjectWithTag("Goal 2");
        borderTop = GameObject.FindGameObjectWithTag("Border Top");
        borderBottom = GameObject.FindGameObjectWithTag("Border Bottom");

        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");

        StartGame();
    }

    void Update()
    {
        NewPosition();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Border Top") || collision.CompareTag("Border Bottom"))
        {
            direction = Mathf.PI * 2 - direction;
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
        speed = 7.0f;

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

        if (direction < 0)
        {
            direction += 360;
        }

        direction = direction * Mathf.PI / 180f;
    }

    public void NewPosition()
    {
        newPosition = new Vector3(ball.transform.localPosition.x + Mathf.Cos(direction) * Time.deltaTime * speed, 0.0f, ball.transform.localPosition.z + Mathf.Sin(direction) * Time.deltaTime * speed);
        ball.transform.localPosition = newPosition;
    }
}
