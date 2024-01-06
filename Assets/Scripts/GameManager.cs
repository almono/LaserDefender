using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndGameOver());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
