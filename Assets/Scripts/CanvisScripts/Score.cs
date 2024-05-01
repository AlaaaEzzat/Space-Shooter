using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score , health;
    private int playerScore, playerHealth;

    private void Start()
    {
        playerHealth = 3;
        playerScore = 0;
    }

    void Update()
    {
        score.text = "Score: " + playerScore;
        health.text = "Health: " + playerHealth;
    }

    public void UpdateScore()
    {
        playerScore += 1;
    }
    public void AddHealth()
    {
        playerHealth += 1;
    }

    public void RemoveHealth()
    {
        playerHealth -= 1;
    }
}
