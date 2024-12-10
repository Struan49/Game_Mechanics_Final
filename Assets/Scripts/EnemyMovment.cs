using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of patrol points
    private int currentPointIndex = 0; // Index to track the current patrol point
    public float speed = 2f; // Movement speed of the enemy
    public float stopDistance = 0.1f; // Distance at which the enemy stops and switches points

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return; // Return if no patrol points are assigned

        // Move towards the current patrol point
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if the enemy is close enough to switch to the next point
        if (Vector2.Distance(transform.position, targetPoint.position) <= stopDistance)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; // Loop through the patrol points
        }
    }
}