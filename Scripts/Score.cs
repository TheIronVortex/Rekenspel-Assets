using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private bool isBallNear;
    [SerializeField] public Transform ball;
    [SerializeField] public char whichGoal;
    private Vector3 initialBallPosition;
    public FootballMath footballMath;
    private char correctGoal;
    [HideInInspector] public bool addPoint;
    public PointCounter pointCounter;
    int points;
    private float lastPointTime;
    public float pointIncrementInterval = 1.0f; // Set the interval to 1 second (you can adjust this as needed)

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform; // Find the ball by tag
        initialBallPosition = ball.position; // Store the initial position of the ball
        addPoint = false;
        lastPointTime = Time.time;
    }

    void Update()
    {
        if (isBallNear)
        {
            correctGoal = footballMath.correctGoal;

            if (correctGoal == whichGoal)
            {
                ResetBallPosition();
                footballMath.GenerateEquation();

                // Check if enough time has passed to increment the point
                if (Time.time - lastPointTime >= pointIncrementInterval)
                {
                    pointCounter.point++;
                    lastPointTime = Time.time; // Update the last point time
                }
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            isBallNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            isBallNear = false;
        }
    }

    private void ResetBallPosition()
    {
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // Stop the ball's movement
        rb.angularVelocity = 0f;    // Stop the ball's rotation
        ball.position = initialBallPosition; // Reset the ball's position
    }
}
