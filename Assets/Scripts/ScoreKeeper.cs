using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] UI uiDisplay;

    private void Awake()
    {
        uiDisplay = FindObjectOfType<UI>();
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
