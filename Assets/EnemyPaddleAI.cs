using System;
using UnityEngine;

public class EnemyPaddleAI : MonoBehaviour
{
    [SerializeField] private Transform ball;
    Rigidbody2D rb;
    private float moveSpeed = 5f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToBall();
    }

    private void MoveToBall()
    {
        float diff = ball.position.y - transform.position.y;
        float threshold = 0.2f;

        if (Mathf.Abs(diff) > threshold)
        {
            float direction = Mathf.Sign(diff);
            rb.linearVelocity = new Vector2(0f, direction * moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
