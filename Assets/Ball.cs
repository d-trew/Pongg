using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;
    public Text P1Score;
    public Text P2Score;
    public GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomInitialVelocity();
    }

    // Set a random initial velocity
    private void SetRandomInitialVelocity()
    {
        float angle = UnityEngine.Random.Range(0f, 360f);
        float angleRad = angle * Mathf.Deg2Rad;
        float xVelocity = Mathf.Cos(angleRad);
        float yVelocity = Mathf.Sin(angleRad);

        rb.velocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("SetRandomInitialVelocity", 1f);
    }

    private void PlayerBounce(Transform myObject)
    {
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection = (transform.position.x > 0) ? -1 : 1;
        float yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        yDirection = (yDirection == 0) ? 0.25f : yDirection;

        rb.velocity = new Vector2(xDirection, yDirection) * startingSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            PlayerBounce(collision.transform);
        }
    }

    private int p1ScoreInt;
    private int p2ScoreInt;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (transform.position.x > 0)
        {
            ResetBall();
            P1Score.text = (int.Parse(P1Score.text) + 1).ToString();
        }
        else
        {
            ResetBall();
            P2Score.text = (int.Parse(P2Score.text) + 1).ToString();
        }

        if (GameIsOver())
        {
            gameOverScreen.Setup(P1Score.text, P2Score.text);
        }
    }

    // Determine when the game is over (you can customize this logic)
    private bool GameIsOver()
    {
        return int.Parse(P1Score.text) >= 1 || int.Parse(P2Score.text) >= 1;
    }
}
