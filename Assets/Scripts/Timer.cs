using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.UI; // Required if using standard Text

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Set the starting countdown time
    public TextMeshProUGUI countdownText; // Drag your TextMeshPro object here
    // public Text countdownText; // Uncomment if using standard Text

    private float timeLeft;

    void Start()
    {
        // Initialize the countdown timer
        timeLeft = countdownTime;
        UpdateCountdownDisplay();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            // Reduce time
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Max(timeLeft, 0); // Clamp at 0
            UpdateCountdownDisplay();
        }
    }

    void UpdateCountdownDisplay()
    {
        // Update the text on the screen
        countdownText.text = Mathf.Ceil(timeLeft).ToString();
    }
}