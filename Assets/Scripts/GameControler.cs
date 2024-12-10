using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Vector2 startPos;
    SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Store the initial position of the GameObject
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Obstacle" tag
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        // Start the respawn coroutine with a delay
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {

        SpriteRenderer.enabled = false;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the GameObject's position
        transform.position = startPos;

        SpriteRenderer.enabled = true;
    }
}