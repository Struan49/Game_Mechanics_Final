using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;

    [Header("Attack Settings")]
    public float timeToAttack = 0.25f; // Duration of the attack animation

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the first child of the player as the attack area
        attackArea = transform.GetChild(0).gameObject;

        // Ensure the attack area is initially inactive
        if (attackArea != null)
        {
            attackArea.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for attack input
        if (Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            Attack();
        }

        // Handle attack duration
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                if (attackArea != null)
                {
                    attackArea.SetActive(false);
                }
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        if (attackArea != null)
        {
            attackArea.SetActive(true);
        }
    }
}
