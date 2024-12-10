using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontalInput;
    private const float MovementSpeed = 4f;
    private const float JumpForce = 16f;
    private bool isFacingRight = true;
    public CoinManager cm;

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundLayerMask;

    private void Update()
{
        // Handle movement input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }

        if (Input.GetButtonUp("Jump") && rigidbody2D.velocity.y > 0f)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y * 0.5f);
        }

        HandleFlip();
}

    private void FixedUpdate()
    {
        // Apply horizontal movement
        rigidbody2D.velocity = new Vector2(horizontalInput * MovementSpeed, rigidbody2D.velocity.y);
    }

    private bool IsOnGround()
    {
        // Check if the player is touching the ground
        return Physics2D.OverlapCircle(groundCheckTransform.position, 0.2f, groundLayerMask);
    }

    private void HandleFlip()
    {
        // Flip the player sprite based on movement direction
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Handle coin collection
        if (other.gameObject.CompareTag("Coin"))
        {
            cm.coinCount++;
            Destroy(other.gameObject);
        }
    }
}