using System;
using Unity.Mathematics;
using UnityEngine;

public class BallController : MonoBehaviour
{

    UIManager uiManager;

    private Vector2 initialPush = new Vector2(1f, 1);
    Rigidbody2D rb;
    public float moveSpeed = 50f;
    private Vector3 startingPosition;
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        uiManager = FindFirstObjectByType<UIManager>();
        startingPosition = transform.position;
        PushBall();
    }

    private void PushBall()
    {
        rb.linearVelocity = initialPush * moveSpeed;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 paddleCenter = collision.collider.bounds.center;

            float offset = contactPoint.y - paddleCenter.y;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, offset * 8f);
        }
        else if (collision.gameObject.CompareTag("ScoreWallLeft"))
        {
            uiManager.UpdateScoreRight();
            transform.position = startingPosition;
            PushBall();
        }
        else if (collision.gameObject.CompareTag("ScoreWallRight"))
        {
            uiManager.UpdateScoreLeft();
            transform.position = startingPosition;
            PushBall();
        }
    }
}
