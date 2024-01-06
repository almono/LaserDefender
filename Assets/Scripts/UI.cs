using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthSlider;
    
    Health playerHealth;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        playerHealth = FindObjectOfType<Health>();
    }

    private void Start()
    {
        healthSlider.value = playerHealth.GetHealth();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
    }

    public void UpdateHealthDisplay()
    {
        healthSlider.value = playerHealth.GetHealth();
    }

    public void UpdateScoreText()
    {
        if(scoreKeeper != null)
        {
            scoreText.text = "Score: " + scoreKeeper.GetScore().ToString("0000000");
        }
    }
}
