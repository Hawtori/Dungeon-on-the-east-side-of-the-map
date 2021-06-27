using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadMenu : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text hScore;

    public void mainMenu()
    {
        Application.LoadLevel(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    private void Update()
    {
        score.text = "Your final score: " + PlayerPrefs.GetFloat("Score", 0).ToString();
        hScore.text = "Your high score: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
}
