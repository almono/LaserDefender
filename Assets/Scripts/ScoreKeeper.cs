using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] UI uiDisplay;

    public static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
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

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this; // 2nd way of creating singleton
            DontDestroyOnLoad(gameObject);
        }
    }
}
